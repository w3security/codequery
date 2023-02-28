/**
 * Provides a taint-tracking configuration for reasoning about unvalidated dynamic
 * method calls.
 */

import javascript
import semmle.javascript.frameworks.Express
import PropertyInjectionShared
private import semmle.javascript.dataflow.InferredTypes

module UnvalidatedDynamicMethodCall {
  private import DataFlow::FlowLabel

  /**
   * A data flow source for unvalidated dynamic method calls.
   */
  abstract class Source extends DataFlow::Node {
    /**
     * Gets the flow label relevant for this source.
     */
    DataFlow::FlowLabel getFlowLabel() {
      result = data()
    }
  }

  /**
   * A data flow sink for unvalidated dynamic method calls.
   */
  abstract class Sink extends DataFlow::Node {
    /**
     * Gets the flow label relevant for this sink
     */
    abstract DataFlow::FlowLabel getFlowLabel();
  }

  /**
   * A sanitizer for unvalidated dynamic method calls.
   */
  abstract class Sanitizer extends DataFlow::Node {
    abstract predicate sanitizes(DataFlow::Node source, DataFlow::Node sink, DataFlow::FlowLabel lbl);
  }

  /**
   * A flow label describing values read from a user-controlled property that
   * may not be functions.
   */
  private class MaybeNonFunction extends DataFlow::FlowLabel {
    MaybeNonFunction() { this = "MaybeNonFunction" }
  }

  /**
   * A flow label describing values read from a user-controlled property that
   * may originate from a prototype object.
   */
  private class MaybeFromProto extends DataFlow::FlowLabel {
    MaybeFromProto() { this = "MaybeFromProto" }
  }

  /**
   * A taint-tracking configuration for reasoning about unvalidated dynamic method calls.
   */
  class Configuration extends TaintTracking::Configuration {
    Configuration() { this = "UnvalidatedDynamicMethodCall" }

    override predicate isSource(DataFlow::Node source, DataFlow::FlowLabel label) {
      source.(Source).getFlowLabel() = label
    }

    override predicate isSink(DataFlow::Node sink, DataFlow::FlowLabel label) {
      sink.(Sink).getFlowLabel() = label
    }

    override predicate isSanitizer(DataFlow::Node nd) {
      super.isSanitizer(nd) or
      nd instanceof PropertyInjection::Sanitizer
    }

    override predicate isAdditionalFlowStep(DataFlow::Node src, DataFlow::Node dst, DataFlow::FlowLabel srclabel, DataFlow::FlowLabel dstlabel) {
      exists (DataFlow::PropRead read |
        src = read.getPropertyNameExpr().flow() and
        dst = read and
        (srclabel = data() or srclabel = taint()) and
        (dstlabel instanceof MaybeNonFunction
         or
         // a property of `Object.create(null)` cannot come from a prototype
         not PropertyInjection::isPrototypeLessObject(read.getBase().getALocalSource()) and
         dstlabel instanceof MaybeFromProto) and
        // avoid overlapping results with unsafe dynamic method access query
        not PropertyInjection::hasUnsafeMethods(read.getBase().getALocalSource())
      )
    }
  }

  /**
   * A source of remote user input, considered as a source for unvalidated dynamic method calls.
   */
  class RemoteFlowSourceAsSource extends Source {
    RemoteFlowSourceAsSource() { this instanceof RemoteFlowSource }
  }

  /**
   * The page URL considered as a flow source for unvalidated dynamic method calls.
   */
  class DocumentUrlAsSource extends Source {
    DocumentUrlAsSource() { isDocumentURL(asExpr()) }
  }

  /**
   * A function invocation of an unsafe function, as a sink for remote unvalidated dynamic method calls.
   */
  class CalleeAsSink extends Sink {
    InvokeExpr invk;

    CalleeAsSink() {
      this = invk.getCallee().flow() and
      // don't flag invocations inside a try-catch
      not invk.getASuccessor() instanceof CatchClause
    }

    override DataFlow::FlowLabel getFlowLabel() {
      result instanceof MaybeNonFunction and
      // don't flag if the type inference can prove that it is a function;
      // this complements the `FunctionCheck` sanitizer below: the type inference can
      // detect more checks locally, but doesn't provide inter-procedural reasoning
      this.analyze().getAType() != TTFunction()
      or
      result instanceof MaybeFromProto
    }
  }

  /**
   * A check of the form `typeof x === 'function'`, which sanitizes away the `MaybeNonFunction`
   * taint kind.
   */
  class FunctionCheck extends TaintTracking::LabeledSanitizerGuardNode, DataFlow::ValueNode {
    override EqualityTest astNode;
    TypeofExpr t;

    FunctionCheck() {
      astNode.getAnOperand().getStringValue() = "function" and
      astNode.getAnOperand().getUnderlyingValue() = t
    }

    override predicate sanitizes(boolean outcome, Expr e) {
      outcome = astNode.getPolarity() and
      e = t.getOperand().getUnderlyingValue()
    }

    override DataFlow::FlowLabel getALabel() {
      result instanceof MaybeNonFunction
    }
  }
}
