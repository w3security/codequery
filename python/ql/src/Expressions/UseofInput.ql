/**
 * @name 'input' function used
 * @description The built-in function 'input' is used which can allow arbitrary code to be run.
 * @kind problem
 * @tags security
 *       correctness
 * @problem.severity error
 * @sub-severity high
 * @precision high
 * @id py/use-of-input
 */

import python

from CallNode call, Context context, ControlFlowNode func
where
context.getAVersion().includes(2, _) and call.getFunction() = func and func.refersTo(context, theInputFunction(), _, _)
select call, "The unsafe built-in function 'input' is used."
