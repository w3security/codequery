/**
 * @name Use of returnless function
 * @description Using the return value of a function that does not return an expression is indicative of a mistake.
 * @kind problem
 * @problem.severity warning
 * @id js/use-of-returnless-function
 * @tags maintainability
 *       correctness
 * @precision high
 */

import javascript
import Declarations.UnusedVariable
import Expressions.ExprHasNoEffect
import Statements.UselessConditional

predicate returnsVoid(Function f) {
  not f.isGenerator() and
  not f.isAsync() and
  not exists(f.getAReturnedExpr())
}

predicate isStub(Function f) {
    f.getBody().(BlockStmt).getNumChild() = 0 
    or
    f instanceof ExternalDecl
}

/**
 * Holds if `e` is in a syntactic context where it likely is fine that the value of `e` comes from a call to a returnless function.
 */
predicate benignContext(Expr e) {
  inVoidContext(e) or 
  
  // A return statement is often used to just end the function.
  e = any(Function f).getAReturnedExpr()
  or 
  exists(ConditionalExpr cond | cond.getABranch() = e and benignContext(cond)) 
  or 
  exists(LogicalBinaryExpr bin | bin.getAnOperand() = e and benignContext(bin)) 
  or
  exists(Expr parent | parent.getUnderlyingValue() = e and benignContext(parent))
  or 
  any(VoidExpr voidExpr).getOperand() = e

  or
  // weeds out calls inside HTML-attributes.
  e.getParent() instanceof CodeInAttribute or  
  // and JSX-attributes.
  e = any(JSXAttribute attr).getValue() or 
  
  exists(AwaitExpr await | await.getOperand() = e and benignContext(await)) 
  or
  // Avoid double reporting with js/trivial-conditional
  isExplicitConditional(_, e)
  or 
  // Avoid double reporting with js/comparison-between-incompatible-types
  any(Comparison binOp).getAnOperand() = e
  or
  // Avoid double reporting with js/property-access-on-non-object
  any(PropAccess ac).getBase() = e
  or
  // Avoid double-reporting with js/unused-local-variable
  exists(VariableDeclarator v | v.getInit() = e and v.getBindingPattern().getVariable() instanceof UnusedLocal)
  or
  // Avoid double reporting with js/call-to-non-callable
  any(InvokeExpr invoke).getCallee() = e
  or
  // arguments to Promise.resolve (and promise library variants) are benign. 
  e = any(ResolvedPromiseDefinition promise).getValue().asExpr()
}

predicate oneshotClosure(InvokeExpr call) {
  call.getCallee().getUnderlyingValue() instanceof ImmediatelyInvokedFunctionExpr
}

predicate alwaysThrows(Function f) {
  exists(ReachableBasicBlock entry, DataFlow::Node throwNode |
    entry = f.getEntryBB() and
    throwNode.asExpr() = any(ThrowStmt t).getExpr() and
    entry.dominates(throwNode.getBasicBlock())
  )
}

from DataFlow::CallNode call
where
  not call.isIndefinite(_) and 
  forex(Function f | f = call.getACallee() |
    returnsVoid(f) and not isStub(f) and not alwaysThrows(f)
  ) and
  
  not benignContext(call.asExpr()) and
  
  // anonymous one-shot closure. Those are used in weird ways and we ignore them.
  not oneshotClosure(call.asExpr())
select
  call, "the function $@ does not return anything, yet the return value is used.", call.getACallee(), call.getCalleeName()
  
