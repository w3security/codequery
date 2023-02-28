/**
 * Provides classes for performing local (intra-procedural) and
 * global (inter-procedural) taint-tracking analyses.
 *
 * We define _taint propagation_ informally to mean that a substantial part of
 * the information from the source is preserved at the sink. For example, taint
 * propagates from `x` to `x + 100`, but it does not propagate from `x` to `x >
 * 100` since we consider a single bit of information to be too little.
 */
import semmle.code.cpp.dataflow.DataFlow
import semmle.code.cpp.dataflow.DataFlow2

module TaintTracking {
  import semmle.code.cpp.dataflow.internal.tainttracking1.TaintTrackingImpl
  private import semmle.code.cpp.dataflow.TaintTracking2

  /**
   * DEPRECATED: Use TaintTracking2::Configuration instead.
   */
  deprecated
  class Configuration2 = TaintTracking2::Configuration;
}
