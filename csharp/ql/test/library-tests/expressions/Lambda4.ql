/**
 * @name Test for lambda expressions
 */

import csharp

from Assignment assign, LambdaExpr e
where
  assign.getLValue().(VariableAccess).getTarget().hasName("f4") and
  e.getParent+() = assign and
  e.getNumberOfParameters() = 1 and
  e.getParameter(0).getType() instanceof IntType and
  e.getParameter(0).hasName("x") and
  e.getType().(DelegateType).getReturnType() instanceof StringType
select e
