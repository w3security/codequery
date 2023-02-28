/**
 * @name Global shadowed by local variable
 * @description Defining a local variable with the same name as a global variable
 *              makes the global variable unusable within the current scope and makes the code
 *              more difficult to read.
 * @kind problem
 * @tags maintainability
 *       readability
 * @problem.severity recommendation
 * @sub-severity low
 * @precision medium
 * @id py/local-shadows-global
 */

import python
import Shadowing

predicate shadows(Name d, GlobalVariable g, Scope scope, int line) {
    exists(LocalVariable l | d.defines(l) and l.getId() = g.getId() and
        scope instanceof Function and g.getScope() = scope.getScope() and
        not exists(Import il, Import ig, Name gd | il.contains(d) and gd.defines(g) and ig.contains(gd)) and
        not exists(Assign a | a.getATarget() = d and a.getValue() = g.getAnAccess())
    ) and
    not exists(builtin_object(g.getId())) and
    d.getScope() = scope and
    d.getLocation().getStartLine() = line and
    exists(Name defn | defn.defines(g) |
        not exists(If i | i.isNameEqMain() | 
            i.contains(defn)
        )
    ) and
    not optimizing_parameter(d)
}

/* pytest dynamically populates its namespace so, we cannot look directly for the pytest.fixture function */
AttrNode pytest_fixture_attr() {
    exists(ModuleObject pytest |
        result.getObject("fixture").refersTo(pytest)
    )
}

Object pytest_fixture() {
    exists(CallNode call |
        call.getFunction() = pytest_fixture_attr()
        or
        call.getFunction().(CallNode).getFunction() = pytest_fixture_attr()
        |
        call.refersTo(result)
    )
}

/* pytest fixtures require that the parameter name is also a global */
predicate assigned_pytest_fixture(GlobalVariable v) {
    exists(NameNode def | def.defines(v) and def.(DefinitionNode).getValue().refersTo(pytest_fixture()))
}

predicate first_shadowing_definition(Name d, GlobalVariable g) {
    exists(int first, Scope scope |
        shadows(d, g, scope, first) and
        first = min(int line | shadows(_, g, scope, line)))
}

from Name d, GlobalVariable g, Name def
where first_shadowing_definition(d, g) and not exists(Name n | n.deletes(g)) and 
      def.defines(g) and not assigned_pytest_fixture(g) and not g.getId() = "_"
select d, "Local variable '" + g.getId() + "' shadows a global variable defined $@.", def, "here"
