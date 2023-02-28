import python

import semmle.python.security.TaintTracking

private ClassObject theTornadoRequestHandlerClass() {
    result = any(ModuleObject m | m.getName() = "tornado.web").getAttribute("RequestHandler")
}

ClassObject aTornadoRequestHandlerClass() {
    result.getASuperType() = theTornadoRequestHandlerClass()
}

FunctionObject getTornadoRequestHandlerMethod(string name) {
    result = theTornadoRequestHandlerClass().declaredAttribute(name)
}

/** Holds if `node` is likely to refer to an instance of a tornado 
 * `RequestHandler` class.
 */

predicate isTornadoRequestHandlerInstance(ControlFlowNode node) {
    node.refersTo(_, aTornadoRequestHandlerClass(), _)
    or
    /* In some cases, the points-to analysis won't capture all instances we care
     * about. For these, we use the following syntactic check. First, that 
     * `node` appears inside a method of a subclass of 
     * `tornado.web.RequestHandler`:*/
    node.getScope().getEnclosingScope().(Class).getClassObject() = aTornadoRequestHandlerClass() and
    /* Secondly, that `node` refers to the `self` argument: */
    node.isLoad() and node.(NameNode).isSelf()
}

CallNode callToNamedTornadoRequestHandlerMethod(string name) {
    isTornadoRequestHandlerInstance(result.getFunction().(AttrNode).getObject(name))
}