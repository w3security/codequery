private import internal.IRInternal
import Instruction
import IRBlock
import cpp
import semmle.code.cpp.ir.implementation.MemoryAccessKind
private import semmle.code.cpp.ir.internal.OperandTag

private newtype TOperand =
  TNonPhiOperand(Instruction useInstr, OperandTag tag, Instruction defInstr) {
    defInstr = Construction::getInstructionOperandDefinition(useInstr, tag)
  } or
  TPhiOperand(PhiInstruction useInstr, Instruction defInstr, IRBlock predecessorBlock) {
    defInstr = Construction::getPhiInstructionOperandDefinition(useInstr, predecessorBlock)
  }

/**
 * A source operand of an `Instruction`. The operand represents a value consumed by the instruction.
 */
class Operand extends TOperand {
  string toString() {
    result = "Operand"
  }

  final Location getLocation() {
    result = getUseInstruction().getLocation()
  }

  final IRFunction getEnclosingIRFunction() {
    result = getUseInstruction().getEnclosingIRFunction()
  }
  
  /**
   * Gets the `Instruction` that consumes this operand.
   */
  Instruction getUseInstruction() {
    none()
  }

  /**
   * Gets the `Instruction` whose result is the value of the operand.
   */
  Instruction getDefinitionInstruction() {
    none()
  }

  /**
   * Gets a prefix to use when dumping the operand in an operand list.
   */
  string getDumpLabel() {
    result = ""
  }

  /**
   * Gets a string describing this operand, suitable for display in IR dumps. This consists of the
   * result ID of the instruction consumed by the operand, plus a label identifying the operand
   * kind.
   *
   * For example: `this:r3_5`
   */
  final string getDumpString() {
    result = getDumpLabel() + getDefinitionInstruction().getResultId()
  }

  /**
   * Get the order in which the operand should be sorted in the operand list.
   */
  int getDumpSortOrder() {
    result = -1
  }

  /**
   * Gets the type of the value consumed by this operand. This is usually the same as the
   * result type of the definition instruction consumed by this operand. For register operands,
   * this is always the case. For some memory operands, the operand type may be different from
   * the definition type, such as in the case of a partial read or a read from a pointer that
   * has been cast to a different type.
   */
  Type getType() {
    result = getDefinitionInstruction().getResultType()
  }

  /**
   * Holds if the value consumed by this operand is a glvalue. If this
   * holds, the value of the operand represents the address of a location,
   * and the type of the location is given by `getType()`. If this does
   * not hold, the value of the operand represents a value whose type is
   * given by `getResultType()`.
   */
  predicate isGLValue() {
    getDefinitionInstruction().isGLValue()
  }

  /**
   * Gets the size of the value consumed by this operand, in bytes. If the operand does not have
   * a known constant size, this predicate does not hold.
   */
  int getSize() {
    result = getType().getSize()
  }
}

/**
 * An operand that consumes a memory result (e.g. the `LoadOperand` on a `Load` instruction).
 */
class MemoryOperand extends Operand {
  MemoryOperand() {
    exists(MemoryOperandTag tag |
      this = TNonPhiOperand(_, tag, _)
    ) or
    this = TPhiOperand(_, _, _)
  }

  override predicate isGLValue() {
    // A `MemoryOperand` can never be a glvalue
    none()
  }

  /**
   * Gets the kind of memory access performed by the operand.
   */
  MemoryAccessKind getMemoryAccess() {
    none()
  }

  /**
   * Returns the operand that holds the memory address from which the current operand loads its
   * value, if any. For example, in `r3 = Load r1, m2`, the result of `getAddressOperand()` for `m2`
   * is `r1`.
   */
  final AddressOperand getAddressOperand() {
    getMemoryAccess().usesAddressOperand() and
    result.getUseInstruction() = getUseInstruction()
  }
}

/**
 * An operand that consumes a register (non-memory) result.
 */
class RegisterOperand extends Operand {
  RegisterOperand() {
    exists(RegisterOperandTag tag |
      this = TNonPhiOperand(_, tag, _)
    )
  }
}

/**
 * An operand that is not an operand of a `PhiInstruction`.
 */
class NonPhiOperand extends Operand, TNonPhiOperand {
  Instruction useInstr;
  Instruction defInstr;
  OperandTag tag;

  NonPhiOperand() {
    this = TNonPhiOperand(useInstr, tag, defInstr)
  }

  override final Instruction getUseInstruction() {
    result = useInstr
  }

  override final Instruction getDefinitionInstruction() {
    result = defInstr
  }

  override final string getDumpLabel() {
    result = tag.getLabel()
  }

  override final int getDumpSortOrder() {
    result = tag.getSortOrder()
  }

  final OperandTag getOperandTag() {
    result = tag
  }
}

class TypedOperand extends NonPhiOperand, MemoryOperand {
  override TypedOperandTag tag;

  override final Type getType() {
    result = Construction::getInstructionOperandType(useInstr, tag)
  }
}

/**
 * The address operand of an instruction that loads or stores a value from
 * memory (e.g. `Load`, `Store`).
 */
class AddressOperand extends NonPhiOperand, RegisterOperand {
  override AddressOperandTag tag;

  override string toString() {
    result = "Address"
  }
}

/**
 * The source value operand of an instruction that loads a value from memory (e.g. `Load`,
 * `ReturnValue`, `ThrowValue`).
 */
class LoadOperand extends TypedOperand {
  override LoadOperandTag tag;

  override string toString() {
    result = "Load"
  }

  override final MemoryAccessKind getMemoryAccess() {
    result instanceof IndirectMemoryAccess
  }
}

/**
 * The source value operand of a `Store` instruction.
 */
class StoreValueOperand extends NonPhiOperand, RegisterOperand {
  override StoreValueOperandTag tag;

  override string toString() {
    result = "StoreValue"
  }
}

/**
 * The sole operand of a unary instruction (e.g. `Convert`, `Negate`, `Copy`).
 */
class UnaryOperand extends NonPhiOperand, RegisterOperand {
  override UnaryOperandTag tag;

  override string toString() {
    result = "Unary"
  }
}

/**
 * The left operand of a binary instruction (e.g. `Add`, `CompareEQ`).
 */
class LeftOperand extends NonPhiOperand, RegisterOperand {
  override LeftOperandTag tag;

  override string toString() {
    result = "Left"
  }
}

/**
 * The right operand of a binary instruction (e.g. `Add`, `CompareEQ`).
 */
class RightOperand extends NonPhiOperand, RegisterOperand {
  override RightOperandTag tag;

  override string toString() {
    result = "Right"
  }
}

/**
 * The condition operand of a `ConditionalBranch` or `Switch` instruction.
 */
class ConditionOperand extends NonPhiOperand, RegisterOperand {
  override ConditionOperandTag tag;

  override string toString() {
    result = "Condition"
  }
}

/**
 * An operand of the special `UnmodeledUse` instruction, representing a value
 * whose set of uses is unknown.
 */
class UnmodeledUseOperand extends NonPhiOperand, MemoryOperand {
  override UnmodeledUseOperandTag tag;

  override string toString() {
    result = "UnmodeledUse"
  }

  override final MemoryAccessKind getMemoryAccess() {
    result instanceof UnmodeledMemoryAccess
  }
}

/**
 * The operand representing the target function of an `Call` instruction.
 */
class CallTargetOperand extends NonPhiOperand, RegisterOperand {
  override CallTargetOperandTag tag;

  override string toString() {
    result = "CallTarget"
  }
}

/**
 * An operand representing an argument to a function call. This includes both
 * positional arguments (represented by `PositionalArgumentOperand`) and the
 * implicit `this` argument, if any (represented by `ThisArgumentOperand`).
 */
class ArgumentOperand extends NonPhiOperand, RegisterOperand {
  override ArgumentOperandTag tag;
}

/**
 * An operand representing the implicit 'this' argument to a member function
 * call.
 */
class ThisArgumentOperand extends ArgumentOperand {
  override ThisArgumentOperandTag tag;

  override string toString() {
    result = "ThisArgument"
  }
}

/**
 * An operand representing an argument to a function call.
 */
class PositionalArgumentOperand extends ArgumentOperand {
  override PositionalArgumentOperandTag tag;
  int argIndex;

  PositionalArgumentOperand() {
    argIndex = tag.getArgIndex()
  }

  override string toString() {
    result = "Arg(" + argIndex + ")"
  }

  /**
   * Gets the zero-based index of the argument.
   */
  final int getIndex() {
    result = argIndex
  }
}

class SideEffectOperand extends TypedOperand {
  override SideEffectOperandTag tag;

  override final int getSize() {
    if getType() instanceof UnknownType then
      result = Construction::getInstructionOperandSize(useInstr, tag)
    else
      result = getType().getSize()
  }

  override MemoryAccessKind getMemoryAccess() {
    useInstr instanceof CallSideEffectInstruction and
    result instanceof EscapedMayMemoryAccess
    or
    useInstr instanceof CallReadSideEffectInstruction and
    result instanceof EscapedMayMemoryAccess
    or
    useInstr instanceof IndirectReadSideEffectInstruction and
    result instanceof IndirectMemoryAccess
    or
    useInstr instanceof BufferReadSideEffectInstruction and
    result instanceof BufferMemoryAccess
    or
    useInstr instanceof IndirectWriteSideEffectInstruction and
    result instanceof IndirectMemoryAccess
    or
    useInstr instanceof BufferWriteSideEffectInstruction and
    result instanceof BufferMemoryAccess
    or
    useInstr instanceof IndirectMayWriteSideEffectInstruction and
    result instanceof IndirectMayMemoryAccess
    or
    useInstr instanceof BufferMayWriteSideEffectInstruction and
    result instanceof BufferMayMemoryAccess
  }
}

/**
 * An operand of a `PhiInstruction`.
 */
class PhiInputOperand extends MemoryOperand, TPhiOperand {
  PhiInstruction useInstr;
  Instruction defInstr;
  IRBlock predecessorBlock;

  PhiInputOperand() {
    this = TPhiOperand(useInstr, defInstr, predecessorBlock)
  }

  override string toString() {
    result = "Phi"
  }

  override final PhiInstruction getUseInstruction() {
    result = useInstr
  }

  override final Instruction getDefinitionInstruction() {
    result = defInstr
  }

  override final int getDumpSortOrder() {
    result = 11 + getPredecessorBlock().getDisplayIndex()
  }

  override final string getDumpLabel() {
    result = "from " + getPredecessorBlock().getDisplayIndex().toString() + ":"
  }

  /**
   * Gets the predecessor block from which this value comes.
   */
  final IRBlock getPredecessorBlock() {
    result = predecessorBlock
  }

  override final MemoryAccessKind getMemoryAccess() {
    result instanceof PhiMemoryAccess
  }
}

/**
 * The total operand of a Chi node, representing the previous value of the memory.
 */
class ChiTotalOperand extends MemoryOperand {
  ChiTotalOperand() {
    this = TNonPhiOperand(_, chiTotalOperand(), _)
  }

  override string toString() {
    result = "ChiTotal"
  }

  override final MemoryAccessKind getMemoryAccess() {
    result instanceof ChiTotalMemoryAccess
  }
}


/**
 * The partial operand of a Chi node, representing the value being written to part of the memory.
 */
class ChiPartialOperand extends MemoryOperand {
  ChiPartialOperand() {
    this = TNonPhiOperand(_, chiPartialOperand(), _)
  }

  override string toString() {
    result = "ChiPartial"
  }

  override final MemoryAccessKind getMemoryAccess() {
    result instanceof ChiPartialMemoryAccess
  }
}
