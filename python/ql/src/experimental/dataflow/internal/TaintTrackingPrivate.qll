private import python
private import experimental.dataflow.DataFlow
private import experimental.dataflow.internal.DataFlowPrivate
private import experimental.dataflow.internal.TaintTrackingPublic

/**
 * Holds if `node` should be a barrier in all global taint flow configurations
 * but not in local taint.
 */
predicate defaultTaintBarrier(DataFlow::Node node) { none() }

/**
 * Holds if the additional step from `nodeFrom` to `nodeTo` should be included in all
 * global taint flow configurations.
 */
predicate defaultAdditionalTaintStep(DataFlow::Node nodeFrom, DataFlow::Node nodeTo) {
  localAdditionalTaintStep(nodeFrom, nodeTo)
  or
  any(AdditionalTaintStep a).step(nodeFrom, nodeTo)
}

/**
 * Holds if taint can flow in one local step from `nodeFrom` to `nodeTo` excluding
 * local data flow steps. That is, `nodeFrom` and `nodeTo` are likely to represent
 * different objects.
 */
predicate localAdditionalTaintStep(DataFlow::Node nodeFrom, DataFlow::Node nodeTo) {
  concatStep(nodeFrom, nodeTo)
  or
  subscriptStep(nodeFrom, nodeTo)
  or
  stringManipulation(nodeFrom, nodeTo)
}

/**
 * Holds if taint can flow from `nodeFrom` to `nodeTo` with a step related to concatenation.
 *
 * Note that since we cannot easily distinguish interesting types (like string, list, tuple),
 * we consider any `+` operation to propagate taint. This is what is done in the JS libraries,
 * and isn't a big problem in practice.
 */
predicate concatStep(DataFlow::CfgNode nodeFrom, DataFlow::CfgNode nodeTo) {
  exists(BinaryExprNode add | add = nodeTo.getNode() |
    add.getOp() instanceof Add and add.getAnOperand() = nodeFrom.getNode()
  )
}

/**
 * Holds if taint can flow from `nodeFrom` to `nodeTo` with a step related to subscripting.
 */
predicate subscriptStep(DataFlow::CfgNode nodeFrom, DataFlow::CfgNode nodeTo) {
  nodeTo.getNode().(SubscriptNode).getObject() = nodeFrom.getNode()
}

/**
 * Holds if taint can flow from `nodeFrom` to `nodeTo` with a step related to string
 * manipulation.
 *
 * Note that since we cannot easily distinguish when something is a string, this can
 * also make taint flow on `<non string>.replace(foo, bar)`.
 */
predicate stringManipulation(DataFlow::CfgNode nodeFrom, DataFlow::CfgNode nodeTo) {
  // transforming something tainted into a string will make the string tainted
  exists(CallNode call | call = nodeTo.getNode() |
    call.getFunction().(NameNode).getId() in ["str", "bytes", "unicode"] and
    (
      nodeFrom.getNode() = call.getArg(0)
      or
      nodeFrom.getNode() = call.getArgByName("object")
    )
  )
  or
  // String methods. Note that this doesn't recognize `meth = "foo".upper; meth()`
  exists(CallNode call, string method_name, ControlFlowNode object |
    call = nodeTo.getNode() and
    object = call.getFunction().(AttrNode).getObject(method_name)
  |
    nodeFrom.getNode() = object and
    method_name in ["capitalize", "casefold", "center", "expandtabs", "format", "format_map",
          "join", "ljust", "lstrip", "lower", "replace", "rjust", "rstrip", "strip", "swapcase",
          "title", "upper", "zfill", "encode", "decode"]
    or
    method_name = "replace" and
    nodeFrom.getNode() = call.getArg(1)
    or
    method_name = "format" and
    nodeFrom.getNode() = call.getAnArg()
    or
    // str -> List[str]
    // TODO: check if these should be handled differently in regards to content
    nodeFrom.getNode() = object and
    method_name in ["partition", "rpartition", "rsplit", "split", "splitlines"]
    or
    // List[str] -> str
    // TODO: check if these should be handled differently in regards to content
    method_name = "join" and
    nodeFrom.getNode() = call.getArg(0)
    or
    // Mapping[str, Any] -> str
    method_name = "format_map" and
    nodeFrom.getNode() = call.getArg(0)
  )
  or
  // % formatting
  exists(BinaryExprNode fmt | fmt = nodeTo.getNode() |
    fmt.getOp() instanceof Mod and
    (
      fmt.getLeft() = nodeFrom.getNode()
      or
      fmt.getRight() = nodeFrom.getNode()
    )
  )
  or
  // string multiplication -- `"foo" * 10`
  exists(BinaryExprNode mult | mult = nodeTo.getNode() |
    mult.getOp() instanceof Mult and
    mult.getLeft() = nodeFrom.getNode()
  )
  or
  // f-strings
  nodeTo.getNode().getNode().(Fstring).getAValue() = nodeFrom.getNode().getNode()
  // TODO: Handle encode/decode from base64/quopri
  // TODO: Handle os.path.join
  // TODO: Handle functions in https://docs.python.org/3/library/binascii.html
}
