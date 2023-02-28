# Improvements to C/C++ analysis

The following changes in version 1.23 affect C/C++ analysis in all applications.

## General improvements

## New queries

| **Query**                   | **Tags**  | **Purpose**                                                        |
|-----------------------------|-----------|--------------------------------------------------------------------|
| Hard-coded Japanese era start date (`cpp/japanese-era/exact-era-date`) | reliability, japanese-era | This query is a combination of two old queries that were identical in purpose but separate as an implementation detail.  This new query replaces Hard-coded Japanese era start date in call (`cpp/japanese-era/constructor-or-method-with-exact-era-date`) and Hard-coded Japanese era start date in struct (`cpp/japanese-era/struct-with-exact-era-date`). |

## Changes to existing queries

| **Query**                  | **Expected impact**    | **Change**                                                       |
|----------------------------|------------------------|------------------------------------------------------------------|
| Query name (`query id`) | Expected impact | Message. |
| Hard-coded Japanese era start date in call (`cpp/japanese-era/constructor-or-method-with-exact-era-date`) | Deprecated | This query has been deprecated.  Use the new combined query Hard-coded Japanese era start date (`cpp/japanese-era/exact-era-date`) instead. |
| Hard-coded Japanese era start date in struct (`cpp/japanese-era/struct-with-exact-era-date`) | Deprecated | This query has been deprecated.  Use the new combined query Hard-coded Japanese era start date (`cpp/japanese-era/exact-era-date`) instead. |
| Hard-coded Japanese era start date (`cpp/japanese-era/exact-era-date`) | More correct results | This query now checks for the beginning date of the Reiwa era (1st May 2019). |
| Sign check of bitwise operation (`cpp/bitwise-sign-check`) | Fewer false positive results | Results involving `>=` or `<=` are no longer reported. |
| Too few arguments to formatting function (`cpp/wrong-number-format-arguments`) | Fewer false positive results | Fixed false positives resulting from mistmatching declarations of a formatting function. |
| Too many arguments to formatting function (`cpp/too-many-format-arguments`) | Fewer false positive results | Fixed false positives resulting from mistmatching declarations of a formatting function. |
| Unclear comparison precedence (`cpp/comparison-precedence`) | Fewer false positive results | False positives involving template classes and functions have been fixed. |
| Comparison of narrow type with wide type in loop condition (`cpp/comparison-with-wider-type`) | Higher precision | The precision of this query has been increased to "high" as the alerts from this query have proved to be valuable on real-world projects. With this precision, results are now displayed by default in LGTM. |

## Changes to QL libraries

* The data-flow library has been extended with a new feature to aid debugging.
  Instead of specifying `isSink(Node n) { any() }` on a configuration to
  explore the possible flow from a source, it is recommended to use the new
  `Configuration::hasPartialFlow` predicate, as this gives a more complete
  picture of the partial flow paths from a given source. The feature is
  disabled by default and can be enabled for individual configurations by
  overriding `int explorationLimit()`.
* The data-flow library now supports flow out of C++ reference parameters.
* The data-flow library now allows flow through the address-of operator (`&`).
* The `DataFlow::DefinitionByReferenceNode` class now considers `f(x)` to be a
  definition of `x` when `x` is a variable of pointer type. It no longer
  considers deep paths such as `f(&x.myField)` to be definitions of `x`. These
  changes are in line with the user expectations we've observed.
* The data-flow library now makes it easier to specify barriers/sanitizers
  arising from guards by overriding the predicate
  `isBarrierGuard`/`isSanitizerGuard` on data-flow and taint-tracking
  configurations respectively.
* There is now a `DataFlow::localExprFlow` predicate and a
  `TaintTracking::localExprTaint` predicate to make it easy to use the most
  common case of local data flow and taint: from one `Expr` to another.
* The member predicates of the `FunctionInput` and `FunctionOutput` classes have been renamed for
  clarity (e.g. `isOutReturnPointer()` to `isReturnValueDeref()`). The existing member predicates
  have been deprecated, and will be removed in a future release. Code that uses the old member
  predicates should be updated to use the corresponding new member predicate.
* The control-flow graph is now computed in QL, not in the extractor. This can
  lead to regressions (or improvements) in how queries are optimized because
  optimization in QL relies on static size estimates, and the control-flow edge
  relations will now have different size estimates than before.
