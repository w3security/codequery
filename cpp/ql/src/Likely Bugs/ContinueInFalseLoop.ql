/**
 * @name Continue statement that does not continue
 * @description A 'continue' statement only re-runs the loop if the loop-condition is true. Therefore
 *              using 'continue' in a loop with a constant false condition is misleading and usually
 *              a bug.
 * @kind problem
 * @id cpp/continue-in-false-loop
 * @problem.severity warning
 */

import cpp

Loop getAFalseLoop() {
  result.getControllingExpr().getValue() = "0"
  and not result.getControllingExpr().isAffectedByMacro()
}

Loop enclosingLoop(Stmt s) {
  exists(Stmt parent |
    parent = s.getParent() and
    if parent instanceof Loop then
      result = parent
    else
      result = enclosingLoop(parent))
}

from Loop loop, ContinueStmt continue
where loop = getAFalseLoop()
  and loop = enclosingLoop(continue)
select continue,
  "This 'continue' never re-runs the loop - the $@ is always false.",
  loop.getControllingExpr(),
  "loop condition"
