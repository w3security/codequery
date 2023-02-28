private import ruby
private import codeql.ruby.DataFlow
private import codeql.ruby.CFG
private import codeql.ruby.Concepts
private import codeql.ruby.Frameworks
private import codeql.ruby.frameworks.ActionController
private import codeql.ruby.frameworks.ActionView
private import codeql.ruby.dataflow.RemoteFlowSources
private import codeql.ruby.dataflow.BarrierGuards
import codeql.ruby.dataflow.internal.DataFlowDispatch
private import codeql.ruby.typetracking.TypeTracker

/**
 * Provides default sources, sinks and sanitizers for detecting
 * "reflected server-side cross-site scripting"
 * vulnerabilities, as well as extension points for adding your own.
 */
module ReflectedXSS {
  /**
   * A data flow source for "reflected server-side cross-site scripting" vulnerabilities.
   */
  abstract class Source extends DataFlow::Node { }

  /**
   * A data flow sink for "reflected server-side cross-site scripting" vulnerabilities.
   */
  abstract class Sink extends DataFlow::Node { }

  /**
   * A sanitizer for "reflected server-side cross-site scripting" vulnerabilities.
   */
  abstract class Sanitizer extends DataFlow::Node { }

  /**
   * A sanitizer guard for "reflected server-side cross-site scripting" vulnerabilities.
   */
  abstract class SanitizerGuard extends DataFlow::BarrierGuard { }

  /**
   * A source of remote user input, considered as a flow source.
   */
  class RemoteFlowSourceAsSource extends Source, RemoteFlowSource { }

  private class ErbOutputMethodCallArgumentNode extends DataFlow::Node {
    private MethodCall call;

    ErbOutputMethodCallArgumentNode() {
      exists(ErbOutputDirective d |
        call = d.getTerminalStmt() and
        this.asExpr().getExpr() = call.getAnArgument()
      )
    }

    MethodCall getCall() { result = call }
  }

  /**
   * An `html_safe` call marking the output as not requiring HTML escaping,
   * considered as a flow sink.
   */
  class HtmlSafeCallAsSink extends Sink {
    HtmlSafeCallAsSink() {
      exists(HtmlSafeCall c, ErbOutputDirective d |
        this.asExpr().getExpr() = c.getReceiver() and
        c = d.getTerminalStmt()
      )
    }
  }

  /**
   * An argument to a call to the `raw` method, considered as a flow sink.
   */
  class RawCallArgumentAsSink extends Sink, ErbOutputMethodCallArgumentNode {
    RawCallArgumentAsSink() { this.getCall() instanceof RawCall }
  }

  /**
   * A argument to a call to the `link_to` method, which does not expect
   * unsanitized user-input, considered as a flow sink.
   */
  class LinkToCallArgumentAsSink extends Sink, ErbOutputMethodCallArgumentNode {
    LinkToCallArgumentAsSink() {
      this.asExpr().getExpr() = this.getCall().(LinkToCall).getPathArgument()
    }
  }

  /**
   * An HTML escaping, considered as a sanitizer.
   */
  class HtmlEscapingAsSanitizer extends Sanitizer {
    HtmlEscapingAsSanitizer() { this = any(HtmlEscaping esc).getOutput() }
  }

  /**
   * A comparison with a constant string, considered as a sanitizer-guard.
   */
  class StringConstCompareAsSanitizerGuard extends SanitizerGuard, StringConstCompare { }

  /**
   * An inclusion check against an array of constant strings, considered as a sanitizer-guard.
   */
  class StringConstArrayInclusionCallAsSanitizerGuard extends SanitizerGuard,
    StringConstArrayInclusionCall { }

  /**
   * A `VariableWriteAccessCfgNode` that is not succeeded (locally) by another
   * write to that variable.
   */
  private class FinalInstanceVarWrite extends CfgNodes::ExprNodes::InstanceVariableWriteAccessCfgNode {
    private InstanceVariable var;

    FinalInstanceVarWrite() {
      var = this.getExpr().getVariable() and
      not exists(CfgNodes::ExprNodes::InstanceVariableWriteAccessCfgNode succWrite |
        succWrite.getExpr().getVariable() = var
      |
        succWrite = this.getASuccessor+()
      )
    }

    InstanceVariable getVariable() { result = var }

    AssignExpr getAnAssignExpr() { result.getLeftOperand() = this.getExpr() }
  }

  /**
   * An additional step that is taint-preserving in the context of reflected XSS.
   */
  predicate isAdditionalXSSTaintStep(DataFlow::Node node1, DataFlow::Node node2) {
    // node1 is a `locals` argument to a render call...
    exists(RenderCall call, Pair kvPair, string hashKey |
      call.getLocals().getAKeyValuePair() = kvPair and
      kvPair.getValue() = node1.asExpr().getExpr() and
      kvPair.getKey().(StringlikeLiteral).getValueText() = hashKey and
      // `node2` appears in the rendered template file
      call.getTemplateFile() = node2.getLocation().getFile() and
      (
        // node2 is an element reference against `local_assigns`
        exists(
          CfgNodes::ExprNodes::ElementReferenceCfgNode refNode, DataFlow::Node argNode,
          CfgNodes::ExprNodes::StringlikeLiteralCfgNode strNode
        |
          refNode = node2.asExpr() and
          argNode.asExpr() = refNode.getArgument(0) and
          refNode.getReceiver().getExpr().(MethodCall).getMethodName() = "local_assigns" and
          argNode.getALocalSource() = DataFlow::exprNode(strNode) and
          strNode.getExpr().getValueText() = hashKey
        )
        or
        // ...node2 is a "method call" to a "method" with `hashKey` as its name
        // TODO: This may be a variable read in reality that we interpret as a method call
        exists(MethodCall varAcc |
          varAcc = node2.asExpr().(CfgNodes::ExprNodes::MethodCallCfgNode).getExpr() and
          varAcc.getMethodName() = hashKey
        )
      )
    )
    or
    // instance variables in the controller
    exists(
      ActionControllerActionMethod action, VariableReadAccess viewVarRead, AssignExpr ae,
      FinalInstanceVarWrite controllerVarWrite
    |
      viewVarRead = node2.asExpr().(CfgNodes::ExprNodes::VariableReadAccessCfgNode).getExpr() and
      action.getDefaultTemplateFile() = viewVarRead.getLocation().getFile() and
      // match read to write on variable name
      viewVarRead.getVariable().getName() = controllerVarWrite.getVariable().getName() and
      // propagate taint from assignment RHS expr to variable read access in view
      ae = controllerVarWrite.getAnAssignExpr() and
      node1.asExpr().getExpr() = ae.getRightOperand() and
      ae.getParent+() = action
    )
    or
    // flow from template into controller helper method
    exists(
      ErbFile template, ActionControllerHelperMethod helperMethod,
      CfgNodes::ExprNodes::MethodCallCfgNode helperMethodCall, int argIdx
    |
      template = node1.getLocation().getFile() and
      helperMethod.getName() = helperMethodCall.getExpr().getMethodName() and
      helperMethod.getControllerClass() = getAssociatedControllerClass(template) and
      helperMethodCall.getArgument(argIdx) = node1.asExpr() and
      helperMethod.getParameter(argIdx) = node2.asExpr().getExpr()
    )
    or
    // flow out of controller helper method into template
    exists(
      ErbFile template, ActionControllerHelperMethod helperMethod,
      CfgNodes::ExprNodes::MethodCallCfgNode helperMethodCall
    |
      template = node2.getLocation().getFile() and
      helperMethod.getName() = helperMethodCall.getExpr().getMethodName() and
      helperMethod.getControllerClass() = getAssociatedControllerClass(template) and
      // `node1` is an expr node that may be returned by the helper method
      exprNodeReturnedFrom(node1, helperMethod) and
      // `node2` is a call to the helper method
      node2.asExpr() = helperMethodCall
    )
  }
}
