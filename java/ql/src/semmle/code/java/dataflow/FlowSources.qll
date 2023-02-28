/**
 * Provides classes representing various flow sources for taint tracking.
 */

import java
import semmle.code.java.dataflow.DataFlow
import semmle.code.java.dataflow.TaintTracking
import semmle.code.java.dataflow.DefUse
import semmle.code.java.frameworks.Jdbc
import semmle.code.java.frameworks.Networking
import semmle.code.java.frameworks.Properties
import semmle.code.java.frameworks.Rmi
import semmle.code.java.frameworks.Servlets
import semmle.code.java.frameworks.ApacheHttp
import semmle.code.java.frameworks.android.XmlParsing
import semmle.code.java.frameworks.android.WebView
import semmle.code.java.frameworks.JaxWS
import semmle.code.java.frameworks.android.Intent
import semmle.code.java.frameworks.SpringWeb

/** Class for `tainted` user input. */
abstract class UserInput extends DataFlow::Node { }

private predicate variableStep(Expr tracked, VarAccess sink) {
  exists(VariableAssign def |
    def.getSource() = tracked and
    defUsePair(def, sink)
  )
}

/** Input that may be controlled by a remote user. */
class RemoteUserInput extends UserInput {
  RemoteUserInput() {
    this.asExpr().(MethodAccess).getMethod() instanceof RemoteTaintedMethod
    or
    // Parameters to RMI methods.
    exists(RemoteCallableMethod method |
      method.getAParameter() = this.asParameter() and
      (
        getType() instanceof PrimitiveType or
        getType() instanceof TypeString
      )
    )
    or
    // Parameters to Jax WS methods.
    exists(JaxWsEndpoint endpoint |
      endpoint.getARemoteMethod().getAParameter() = this.asParameter()
    )
    or
    // Parameters to Jax Rs methods.
    exists(JaxRsResourceClass service |
      service.getAnInjectableCallable().getAParameter() = this.asParameter() or
      service.getAnInjectableField().getAnAccess() = this.asExpr()
    )
    or
    // Reverse DNS. Try not to trigger on `localhost`.
    exists(MethodAccess m | m = this.asExpr() |
      m.getMethod() instanceof ReverseDNSMethod and
      not exists(MethodAccess l |
        (variableStep(l, m.getQualifier()) or l = m.getQualifier()) and
        l.getMethod().getName() = "getLocalHost"
      )
    )
    or
    //MessageBodyReader
    exists(MessageBodyReaderRead m |
      m.getParameter(4) = this.asParameter() or
      m.getParameter(5) = this.asParameter()
    )
    or
    this.asParameter().getAnAnnotation() instanceof SpringServletInputAnnotation
  }

  /**
   * DEPRECATED: Use a configuration with a defined sink instead.
   *
   * Holds if taint can flow from this `RemoteUserInput` to `sink`.
   *
   * In addition to the basic taint flow, this allows a path to end in a number
   * of steps through instance fields.
   */
  deprecated predicate flowsTo(DataFlow::Node sink) { remoteUserInputFlow(this, sink) }
}

/**
 * Holds if taint can flow from `node1` to `node2` in either one local step or
 * through an instance field.
 */
private predicate localInstanceFieldStep(DataFlow::Node node1, DataFlow::Node node2) {
  TaintTracking::localTaintStep(node1, node2)
  or
  exists(InstanceField field |
    node1.asExpr() = field.getAnAssignedValue()
    or
    exists(Assignment assign | assign.getRhs() = node1.asExpr() |
      assign.getDest().(ArrayAccess).getArray() = field.getAnAccess()
    )
  |
    node2.asExpr() = field.getAnAccess()
  )
}

private module RemoteUserInputFlow {
  private import semmle.code.java.dataflow.internal.DataFlowImplDepr
  private import semmle.code.java.security.SecurityTests
  private import semmle.code.java.security.Validation

  deprecated class RemoteUserInputConfig extends Configuration {
    RemoteUserInputConfig() { this = "FlowSources.qll:RemoteUserInputConfig" }

    override predicate isSource(DataFlow::Node source) { source instanceof RemoteUserInput }

    override predicate isSink(DataFlow::Node sink) { any() }

    override int fieldFlowBranchLimit() { result = 0 }

    override predicate isBarrier(DataFlow::Node node) {
      // Ignore paths through test code.
      node.getEnclosingCallable().getDeclaringType() instanceof NonSecurityTestClass or
      exists(ValidatedVariable var | node.asExpr() = var.getAnAccess())
    }

    override predicate isAdditionalFlowStep(DataFlow::Node node1, DataFlow::Node node2) {
      TaintTracking::localAdditionalTaintStep(node1, node2)
    }
  }
}

cached
deprecated private predicate remoteUserInputFlow(RemoteUserInput src, DataFlow::Node sink) {
  any(RemoteUserInputFlow::RemoteUserInputConfig config).hasFlow(src, sink)
  or
  exists(DataFlow::Node mid |
    remoteUserInputFlow(src, mid) and
    localInstanceFieldStep(mid, sink)
  )
}

/** Input that may be controlled by a local user. */
abstract class LocalUserInput extends UserInput { }

class EnvInput extends LocalUserInput {
  EnvInput() {
    // Parameters to a main method.
    exists(MainMethod main | this.asParameter() = main.getParameter(0))
    or
    // Args4j arguments.
    exists(Field f | this.asExpr() = f.getAnAccess() |
      f.getAnAnnotation().getType().getQualifiedName() = "org.kohsuke.args4j.Argument"
    )
    or
    // Results from various specific methods.
    this.asExpr().(MethodAccess).getMethod() instanceof EnvTaintedMethod
    or
    // Access to `System.in`.
    exists(Field f | this.asExpr() = f.getAnAccess() | f instanceof SystemIn)
    or
    // Access to files.
    this
        .asExpr()
        .(ConstructorCall)
        .getConstructedType()
        .hasQualifiedName("java.io", "FileInputStream")
  }
}

class DatabaseInput extends LocalUserInput {
  DatabaseInput() { this.asExpr().(MethodAccess).getMethod() instanceof ResultSetGetStringMethod }
}

private class RemoteTaintedMethod extends Method {
  RemoteTaintedMethod() {
    this instanceof ServletRequestGetParameterMethod or
    this instanceof ServletRequestGetParameterMapMethod or
    this instanceof ServletRequestGetParameterNamesMethod or
    this instanceof HttpServletRequestGetQueryStringMethod or
    this instanceof HttpServletRequestGetHeaderMethod or
    this instanceof HttpServletRequestGetPathMethod or
    this instanceof HttpServletRequestGetHeadersMethod or
    this instanceof HttpServletRequestGetHeaderNamesMethod or
    this instanceof HttpServletRequestGetRequestURIMethod or
    this instanceof HttpServletRequestGetRequestURLMethod or
    this instanceof HttpServletRequestGetRemoteUserMethod or
    this instanceof ServletRequestGetBodyMethod or
    this instanceof CookieGetValueMethod or
    this instanceof CookieGetNameMethod or
    this instanceof CookieGetCommentMethod or
    this instanceof URLConnectionGetInputStreamMethod or
    this instanceof SocketGetInputStreamMethod or
    this instanceof ApacheHttpGetParams or
    this instanceof ApacheHttpEntityGetContent or
    // In the setting of Android we assume that XML has been transmitted over
    // the network, so may be tainted.
    this instanceof XmlPullGetMethod or
    this instanceof XmlAttrSetGetMethod or
    // The current URL in a browser may be untrusted or uncontrolled.
    this instanceof WebViewGetUrlMethod
  }
}

private class EnvTaintedMethod extends Method {
  EnvTaintedMethod() {
    this instanceof MethodSystemGetenv or
    this instanceof PropertiesGetPropertyMethod or
    this instanceof MethodSystemGetProperty
  }
}

class TypeInetAddr extends RefType {
  TypeInetAddr() { this.getQualifiedName() = "java.net.InetAddress" }
}

class ReverseDNSMethod extends Method {
  ReverseDNSMethod() {
    this.getDeclaringType() instanceof TypeInetAddr and
    (
      this.getName() = "getHostName" or
      this.getName() = "getCanonicalHostName"
    )
  }
}

/** Android `Intent` that may have come from a hostile application. */
class AndroidIntentInput extends DataFlow::Node {
  AndroidIntentInput() {
    exists(MethodAccess ma, AndroidGetIntentMethod m |
      ma.getMethod().overrides*(m) and
      this.asExpr() = ma
    )
    or
    exists(Method m, AndroidReceiveIntentMethod rI |
      m.overrides*(rI) and
      this.asParameter() = m.getParameter(1)
    )
  }
}
