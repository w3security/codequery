// generated by codegen/codegen.py
private import codeql.swift.generated.Synth
private import codeql.swift.generated.Raw
import codeql.swift.elements.type.Type

module Generated {
  class ExistentialType extends Synth::TExistentialType, Type {
    override string getAPrimaryQlClass() { result = "ExistentialType" }

    /**
     * Gets the constraint of this existential type.
     *
     * This includes nodes from the "hidden" AST. It can be overridden in subclasses to change the
     * behavior of both the `Immediate` and non-`Immediate` versions.
     */
    Type getImmediateConstraint() {
      result =
        Synth::convertTypeFromRaw(Synth::convertExistentialTypeToRaw(this)
              .(Raw::ExistentialType)
              .getConstraint())
    }

    /**
     * Gets the constraint of this existential type.
     */
    final Type getConstraint() { result = getImmediateConstraint().resolve() }
  }
}