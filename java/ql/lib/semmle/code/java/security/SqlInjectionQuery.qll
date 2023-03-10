/**
 * Provides taint tracking and dataflow configurations to be used in Sql injection queries.
 *
 * Do not import this from a library file, in order to reduce the risk of
 * unintentionally bringing a TaintTracking::Configuration into scope in an unrelated
 * query.
 */

import java
import semmle.code.java.dataflow.FlowSources
import semmle.code.java.security.QueryInjection

/**
 * A taint-tracking configuration for unvalidated user input that is used in SQL queries.
 */
class QueryInjectionFlowConfig extends TaintTracking::Configuration {
  QueryInjectionFlowConfig() { this = "SqlInjectionLib::QueryInjectionFlowConfig" }

  override predicate isSource(DataFlow::Node src) { src instanceof RemoteFlowSource }

  override predicate isSink(DataFlow::Node sink) { sink instanceof QueryInjectionSink }

  override predicate isSanitizer(DataFlow::Node node) {
    node.getType() instanceof PrimitiveType or
    node.getType() instanceof BoxedType or
    node.getType() instanceof NumberType
  }

  override predicate isAdditionalTaintStep(DataFlow::Node node1, DataFlow::Node node2) {
    any(AdditionalQueryInjectionTaintStep s).step(node1, node2)
  }
}

/**
 * Implementation of `SqlTainted.ql`. This is extracted to a QLL so that it
 * can be excluded from `SqlConcatenated.ql` to avoid overlapping results.
 */
predicate queryTaintedBy(
  QueryInjectionSink query, DataFlow::PathNode source, DataFlow::PathNode sink
) {
  exists(QueryInjectionFlowConfig conf | conf.hasFlowPath(source, sink) and sink.getNode() = query)
}
