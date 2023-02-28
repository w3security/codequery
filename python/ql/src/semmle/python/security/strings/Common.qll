import python


/* A call that returns a copy (or similar) of the argument */
predicate copy_call(ControlFlowNode fromnode, CallNode tonode) {
    tonode.getFunction().(AttrNode).getObject("copy") = fromnode
    or
    exists(ModuleObject copy, string name |
        name = "copy" or name = "deepcopy" |
        copy.getAttribute(name).(FunctionObject).getACall() = tonode and
        tonode.getArg(0) = fromnode
    )
    or
    tonode.getFunction().refersTo(builtin_object("reversed")) and
    tonode.getArg(0) = fromnode
}
