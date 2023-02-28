import semmle.code.cpp.Function
import semmle.code.cpp.models.interfaces.ArrayFunction
import semmle.code.cpp.models.interfaces.DataFlow
import semmle.code.cpp.models.interfaces.Taint

/**
 * The standard functions `memcpy` and `memmove`, and the gcc variant
 * `__builtin___memcpy_chk`
 */
class MemcpyFunction extends ArrayFunction, DataFlowFunction, TaintFunction {
  MemcpyFunction() {
    this.hasName("memcpy") or
    this.hasName("memmove") or
    this.hasName("__builtin___memcpy_chk")
  }

  override predicate hasArrayInput(int bufParam) {
    bufParam = 1
  }

  override predicate hasArrayOutput(int bufParam) {
    bufParam = 0
  }

  override predicate hasDataFlow(FunctionInput input, FunctionOutput output) {
    (
      input.isInParameterPointer(1) and
      output.isOutParameterPointer(0)
    ) or (
      input.isInParameterPointer(1) and
      output.isOutReturnPointer()
    ) or (
      input.isInParameter(0) and
      output.isOutReturnValue()
    )
  }
  
  override predicate hasTaintFlow(FunctionInput input, FunctionOutput output) {
    (
      input.isInParameter(2) and
      output.isOutParameterPointer(0)
    ) or (
      input.isInParameter(2) and
      output.isOutReturnPointer()
    )
  }

  override predicate hasArrayWithVariableSize(int bufParam, int countParam) {
    (
      bufParam = 0 or
      bufParam = 1
    ) and
    countParam = 2
  }
}