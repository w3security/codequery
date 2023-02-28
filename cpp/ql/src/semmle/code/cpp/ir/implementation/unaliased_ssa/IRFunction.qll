private import internal.IRInternal
import Instruction
import cpp

private newtype TIRFunction =
  MkIRFunction(Function func) {
    Construction::functionHasIR(func)
  }

/**
 * Represents the IR for a function.
 */
class IRFunction extends TIRFunction {
  Function func;

  IRFunction() {
    this = MkIRFunction(func)
  }

  final string toString() {
    result = "IR: " + func.toString()
  }

  /**
   * Gets the function whose IR is represented.
   */
  final Function getFunction() {
    result = func
  }

  /**
   * Gets the location of the function.
   */
  final Location getLocation() {
    result = func.getLocation()
  }

  /**
   * Gets the entry point for this function.
   */
  pragma[noinline]
  final EnterFunctionInstruction getEnterFunctionInstruction() {
    result.getEnclosingIRFunction() = this
  }

  /**
   * Gets the exit point for this function.
   */
  pragma[noinline]
  final ExitFunctionInstruction getExitFunctionInstruction() {
    result.getEnclosingIRFunction() = this
  }

  pragma[noinline]
  final UnmodeledDefinitionInstruction getUnmodeledDefinitionInstruction() {
    result.getEnclosingIRFunction() = this
  }

  pragma[noinline]
  final UnmodeledUseInstruction getUnmodeledUseInstruction() {
    result.getEnclosingIRFunction() = this
  }

  /**
   * Gets the single return instruction for this function.
   */
  pragma[noinline]
  final ReturnInstruction getReturnInstruction() {
    result.getEnclosingIRFunction() = this
  }

  /**
   * Gets the variable used to hold the return value of this function. If this
   * function does not return a value, this predicate does not hold.
   */
  pragma[noinline]
  final IRReturnVariable getReturnVariable() {
    result.getEnclosingIRFunction() = this
  }
  
  /**
   * Gets the block containing the entry point of this function.
   */  
  pragma[noinline]
  final IRBlock getEntryBlock() {
    result.getFirstInstruction() = getEnterFunctionInstruction()
  }

  /**
   * Gets all instructions in this function.
   */
  final Instruction getAnInstruction() {
    result.getEnclosingIRFunction() = this
  }

  /**
   * Gets all blocks in this function.
   */
  final IRBlock getABlock() {
    result.getEnclosingIRFunction() = this
  }
}
