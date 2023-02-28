/**
 * @name Definitions
 * @description Jump to definition helper query.
 * @kind definitions
 * @id rb/jump-to-definition
 */

/*
 * TODO:
 *    - should `Foo.new` point to `Foo#initialize`?
 */

import ruby
import codeql.ruby.ast.internal.Module
import codeql.ruby.dataflow.SSA

from DefLoc loc, Expr src, Expr target, string kind
where
  ConstantDefLoc(src, target) = loc and kind = "constant"
  or
  MethodLoc(src, target) = loc and kind = "method"
  or
  LocalVariableLoc(src, target) = loc and kind = "variable"
  or
  InstanceVariableLoc(src, target) = loc and kind = "instance variable"
  or
  ClassVariableLoc(src, target) = loc and kind = "class variable"
select src, target, kind

/**
 * Definition location info for different identifiers.
 * Each branch holds two values that are subclasses of `Expr`.
 * The first is the "source" - some usage of an identifier.
 * The second is the "target" - the definition of that identifier.
 */
newtype DefLoc =
  /** A constant, module or class. */
  ConstantDefLoc(ConstantReadAccess read, ConstantWriteAccess write) { write = definitionOf(read) } or
  /** A method call. */
  MethodLoc(MethodCall call, Method meth) { meth = call.getATarget() } or
  /** A local variable. */
  LocalVariableLoc(VariableReadAccess read, VariableWriteAccess write) {
    exists(Ssa::WriteDefinition w |
      write = w.getWriteAccess() and
      read = w.getARead().getExpr() and
      not read.isSynthesized()
    )
  } or
  /** An instance variable */
  InstanceVariableLoc(InstanceVariableReadAccess read, InstanceVariableWriteAccess write) {
    /*
     * We consider instance variables to be "defined" in the initialize method of their enclosing class.
     * If that method doesn't exist, we won't provide any jump-to-def information for the instance variable.
     */

    exists(Method m |
      m.getAChild+() = write and
      m.getName() = "initialize" and
      write.getVariable() = read.getVariable()
    )
  } or
  /** A class variable */
  ClassVariableLoc(ClassVariableReadAccess read, ClassVariableWriteAccess write) {
    read.getVariable() = write.getVariable() and
    not exists(MethodBase m | m.getAChild+() = write)
  }

/**
 * Gets the fully qualified name for a constant, based on the context in which it is defined.
 *
 *  For example, given
 *  ```ruby
 *  module Foo
 *    module Bar
 *      class Baz
 *      end
 *    end
 *  end
 *  ```
 *
 *  the constant `Baz` has the fully qualified name `Foo::Bar::Baz`.
 */
string constantQualifiedName(ConstantWriteAccess w) {
  /* get the qualified name for the parent module, then append w */
  exists(ConstantWriteAccess parent | parent = w.getEnclosingModule() |
    result = constantQualifiedName(parent) + "::" + w.getName()
  )
  or
  /* base case - there's no parent module */
  not exists(ConstantWriteAccess parent | parent = w.getEnclosingModule()) and
  result = w.getName()
}

/**
 * Gets the constant write that defines the given constant.
 *  Modules often don't have a unique definition, as they are opened multiple times in different
 *  files. In these cases we arbitrarily pick the definition with the lexicographically least
 *  location.
 */
ConstantWriteAccess definitionOf(ConstantReadAccess r) {
  result =
    min(ConstantWriteAccess w |
      constantQualifiedName(w) = resolveConstant(r)
    |
      w order by w.getLocation().toString()
    )
}
