/**
 * Provides classes and predicates for tracking data flow through library types.
 */

import csharp
private import semmle.code.csharp.frameworks.System
private import semmle.code.csharp.frameworks.system.Collections
private import semmle.code.csharp.frameworks.system.collections.Generic
private import semmle.code.csharp.frameworks.system.linq.Expressions
private import semmle.code.csharp.frameworks.system.Text
private import semmle.code.csharp.frameworks.system.runtime.CompilerServices
private import semmle.code.csharp.frameworks.system.threading.Tasks
private import semmle.code.csharp.dataflow.internal.DataFlowPrivate
private import semmle.code.csharp.dataflow.internal.DataFlowPublic
private import semmle.code.csharp.dataflow.internal.DelegateDataFlow
// import `LibraryTypeDataFlow` definitions from other files to avoid potential reevaluation
private import semmle.code.csharp.frameworks.EntityFramework
private import FlowSummary

private newtype TAccessPath =
  TNilAccessPath() or
  TConsAccessPath(Content head, AccessPath tail) {
    tail = TNilAccessPath()
    or
    exists(LibraryTypeDataFlow ltdf |
      ltdf.requiresAccessPath(head, tail) and
      tail.length() < accessPathLimit()
    )
    or
    tail = AccessPath::singleton(_) and
    head instanceof ElementContent
    or
    tail = AccessPath::element()
  }

/** An access path. */
class AccessPath extends TAccessPath {
  /** Gets the head of this access path, if any. */
  Content getHead() { this = TConsAccessPath(result, _) }

  /** Gets the tail of this access path, if any. */
  AccessPath getTail() { this = TConsAccessPath(_, result) }

  /** Gets the length of this access path. */
  int length() {
    this = TNilAccessPath() and result = 0
    or
    result = 1 + this.getTail().length()
  }

  /** Gets the access path obtained by dropping the first `i` elements, if any. */
  AccessPath drop(int i) {
    i = 0 and result = this
    or
    result = this.getTail().drop(i - 1)
  }

  /** Holds if this access path contains content `c`. */
  predicate contains(Content c) { c = this.drop(_).getHead() }

  /** Gets a textual representation of this access path. */
  string toString() {
    exists(Content head, AccessPath tail |
      head = this.getHead() and
      tail = this.getTail() and
      if tail.length() = 0 then result = head.toString() else result = head + ", " + tail
    )
    or
    this = TNilAccessPath() and
    result = "<empty>"
  }
}

/** Provides predicates for constructing access paths. */
module AccessPath {
  /** Gets the empty access path. */
  AccessPath empty() { result = TNilAccessPath() }

  /** Gets a singleton access path containing `c`. */
  AccessPath singleton(Content c) { result = TConsAccessPath(c, TNilAccessPath()) }

  /** Gets the access path obtained by concatenating `head` onto `tail`. */
  AccessPath cons(Content head, AccessPath tail) { result = TConsAccessPath(head, tail) }

  /** Gets the singleton "element content" access path. */
  AccessPath element() { result = singleton(any(ElementContent c)) }

  /** Gets a singleton property access path. */
  AccessPath property(Property p) {
    result = singleton(any(PropertyContent c | c.getProperty() = p.getUnboundDeclaration()))
  }

  /** Gets a singleton field access path. */
  AccessPath field(Field f) {
    result = singleton(any(FieldContent c | c.getField() = f.getUnboundDeclaration()))
  }

  /** Gets a singleton synthetic field access path. */
  AccessPath synthetic(SyntheticField f) {
    result = singleton(any(SyntheticFieldContent c | c.getField() = f))
  }

  /** Gets an access path representing a property inside a collection. */
  AccessPath properties(Property p) { result = TConsAccessPath(any(ElementContent c), property(p)) }
}

/** An unbound callable. */
class SourceDeclarationCallable extends Callable {
  SourceDeclarationCallable() { this.isUnboundDeclaration() }
}

/** An unbound method. */
class SourceDeclarationMethod extends SourceDeclarationCallable, Method { }

private newtype TCallableFlowSource =
  TCallableFlowSourceQualifier() or
  TCallableFlowSourceArg(int i) { i = any(Parameter p).getPosition() } or
  TCallableFlowSourceDelegateArg(int i) { hasDelegateArgumentPosition(_, i) }

private predicate hasDelegateArgumentPosition(SourceDeclarationCallable c, int i) {
  exists(DelegateType dt |
    dt = c.getParameter(i).getType().(SystemLinqExpressions::DelegateExtType).getDelegateType()
  |
    not dt.getReturnType() instanceof VoidType
  )
}

private predicate hasDelegateArgumentPosition2(SourceDeclarationCallable c, int i, int j) {
  exists(DelegateType dt |
    dt = c.getParameter(i).getType().(SystemLinqExpressions::DelegateExtType).getDelegateType()
  |
    exists(dt.getParameter(j))
  )
}

/** A flow source specification. */
class CallableFlowSource extends TCallableFlowSource {
  /** Gets a textual representation of this flow source specification. */
  string toString() { none() }

  /** Gets the source of flow for call `c`, if any. */
  Expr getSource(Call c) { none() }

  /**
   * Gets the type of the source for call `c`. Unlike `getSource()`, this
   * is defined for all flow source specifications.
   */
  Type getSourceType(Call c) { result = this.getSource(c).getType() }
}

/** A flow source specification: (method call) qualifier. */
class CallableFlowSourceQualifier extends CallableFlowSource, TCallableFlowSourceQualifier {
  override string toString() { result = "qualifier" }

  override Expr getSource(Call c) { result = c.getChild(-1) }
}

/** A flow source specification: (method call) argument. */
class CallableFlowSourceArg extends CallableFlowSource, TCallableFlowSourceArg {
  private int i;

  CallableFlowSourceArg() { this = TCallableFlowSourceArg(i) }

  /** Gets the index of this argument. */
  int getArgumentIndex() { result = i }

  override string toString() { result = "argument " + i }

  override Expr getSource(Call c) { result = c.getArgument(i) }
}

/** A flow source specification: output from delegate argument. */
class CallableFlowSourceDelegateArg extends CallableFlowSource, TCallableFlowSourceDelegateArg {
  private int i;

  CallableFlowSourceDelegateArg() { this = TCallableFlowSourceDelegateArg(i) }

  /** Gets the index of this delegate argument. */
  int getArgumentIndex() { result = i }

  override string toString() { result = "output from argument " + i }

  override Expr getSource(Call c) { none() }

  override Type getSourceType(Call c) { result = c.getArgument(i).getType() }
}

private newtype TCallableFlowSink =
  TCallableFlowSinkQualifier() or
  TCallableFlowSinkReturn() or
  TCallableFlowSinkArg(int i) { exists(SourceDeclarationCallable c | exists(c.getParameter(i))) } or
  TCallableFlowSinkDelegateArg(int i, int j) { hasDelegateArgumentPosition2(_, i, j) }

/** A flow sink specification. */
class CallableFlowSink extends TCallableFlowSink {
  /** Gets a textual representation of this flow sink specification. */
  string toString() { none() }

  /** Gets the sink of flow for call `c`, if any. */
  Expr getSink(Call c) { none() }
}

/** A flow sink specification: (method call) qualifier. */
class CallableFlowSinkQualifier extends CallableFlowSink, TCallableFlowSinkQualifier {
  override string toString() { result = "qualifier" }

  override Expr getSink(Call c) { result = c.getChild(-1) }
}

/** A flow sink specification: return value. */
class CallableFlowSinkReturn extends CallableFlowSink, TCallableFlowSinkReturn {
  override string toString() { result = "return" }

  override Expr getSink(Call c) { result = c }
}

/** A flow sink specification: (method call) argument. */
class CallableFlowSinkArg extends CallableFlowSink, TCallableFlowSinkArg {
  private int i;

  CallableFlowSinkArg() { this = TCallableFlowSinkArg(i) }

  /** Gets the index of this `out`/`ref` argument. */
  int getArgumentIndex() { result = i }

  /** Gets the `out`/`ref` argument of method call `mc` matching this specification. */
  Expr getArgument(MethodCall mc) {
    exists(Parameter p |
      p = mc.getTarget().getParameter(i) and
      p.isOutOrRef() and
      result = mc.getArgumentForParameter(p)
    )
  }

  override string toString() { result = "argument " + i }

  override Expr getSink(Call c) {
    // The uses of the `i`th argument are the actual sinks
    none()
  }
}

/** Gets the flow source for argument `i` of delegate `callable`. */
private CallableFlowSourceDelegateArg getDelegateFlowSourceArg(
  SourceDeclarationCallable callable, int i
) {
  i = result.getArgumentIndex() and
  hasDelegateArgumentPosition(callable, i)
}

/** Gets the flow sink for the `j`th argument of the delegate at argument `i` of `callable`. */
private CallableFlowSinkDelegateArg getDelegateFlowSinkArg(
  SourceDeclarationCallable callable, int i, int j
) {
  result = TCallableFlowSinkDelegateArg(i, j) and
  hasDelegateArgumentPosition2(callable, i, j)
}

/** A flow sink specification: parameter of a delegate argument. */
class CallableFlowSinkDelegateArg extends CallableFlowSink, TCallableFlowSinkDelegateArg {
  private int delegateIndex;
  private int parameterIndex;

  CallableFlowSinkDelegateArg() {
    this = TCallableFlowSinkDelegateArg(delegateIndex, parameterIndex)
  }

  /** Gets the index of the delegate argument. */
  int getDelegateIndex() { result = delegateIndex }

  /** Gets the index of the delegate parameter. */
  int getDelegateParameterIndex() { result = parameterIndex }

  override string toString() {
    result = "parameter " + parameterIndex + " of argument " + delegateIndex
  }

  override Expr getSink(Call c) {
    // The uses of the `j`th parameter are the actual sinks
    none()
  }
}

/** A specification of data flow for a library (non-source code) type. */
abstract class LibraryTypeDataFlow extends Type {
  LibraryTypeDataFlow() { this = this.getUnboundDeclaration() }

  /**
   * Holds if data may flow from `source` to `sink` when calling callable `c`.
   *
   * `preservesValue` indicates whether the value from `source` is preserved
   * (possibly copied) to `sink`. For example, the value is preserved from `x`
   * to `x.ToString()` when `x` is a `string`, but not from `x` to `x.ToLower()`.
   */
  pragma[nomagic]
  predicate callableFlow(
    CallableFlowSource source, CallableFlowSink sink, SourceDeclarationCallable c,
    boolean preservesValue
  ) {
    none()
  }

  /**
   * Holds if data may flow from `source` to `sink` when calling callable `c`.
   *
   * `sourceAp` describes the contents of `source` that flows to `sink`
   * (if any), and `sinkAp` describes the contents of `sink` that it
   * flows to (if any).
   */
  pragma[nomagic]
  predicate callableFlow(
    CallableFlowSource source, AccessPath sourceAp, CallableFlowSink sink, AccessPath sinkAp,
    SourceDeclarationCallable c, boolean preservesValue
  ) {
    none()
  }

  /**
   * Holds if the access path obtained by concatenating `head` onto `tail` is
   * needed for a summary specified by `callableFlow()`.
   *
   * This predicate is needed for QL technical reasons only (the IPA type used
   * to represent access paths needs to be bounded).
   */
  predicate requiresAccessPath(Content head, AccessPath tail) { none() }

  /**
   * Holds if values stored inside `content` are cleared on objects passed as
   * arguments of type `source` to calls that target `callable`.
   */
  pragma[nomagic]
  predicate clearsContent(
    CallableFlowSource source, Content content, SourceDeclarationCallable callable
  ) {
    none()
  }
}

/**
 * An internal module for translating old `LibraryTypeDataFlow`-style
 * flow summaries into the new style.
 */
private module FrameworkDataFlowAdaptor {
  private CallableFlowSource toCallableFlowSource(SummaryComponentStack input) {
    result = TCallableFlowSourceQualifier() and
    input = SummaryComponentStack::qualifier()
    or
    exists(int i |
      result = TCallableFlowSourceArg(i) and
      input = SummaryComponentStack::argument(i)
    )
    or
    exists(int i | result = TCallableFlowSourceDelegateArg(i) |
      input =
        SummaryComponentStack::push(SummaryComponent::return(), SummaryComponentStack::argument(i))
    )
  }

  private CallableFlowSink toCallableFlowSink(SummaryComponentStack output) {
    result = TCallableFlowSinkQualifier() and
    output = SummaryComponentStack::qualifier()
    or
    result = TCallableFlowSinkReturn() and
    output = SummaryComponentStack::return()
    or
    exists(int i |
      result = TCallableFlowSinkArg(i) and
      output = SummaryComponentStack::argument(i)
    )
    or
    exists(int i, int j | result = TCallableFlowSinkDelegateArg(i, j) |
      output =
        SummaryComponentStack::push(SummaryComponent::parameter(j),
          SummaryComponentStack::argument(i))
    )
  }

  private class FrameworkDataFlowAdaptor extends SummarizedCallable {
    private LibraryTypeDataFlow ltdf;

    FrameworkDataFlowAdaptor() {
      ltdf.callableFlow(_, _, this, _) or
      ltdf.callableFlow(_, _, _, _, this, _) or
      ltdf.clearsContent(_, _, this)
    }

    predicate input(
      CallableFlowSource source, AccessPath sourceAp, SummaryComponent head,
      SummaryComponentStack tail, int i
    ) {
      ltdf.callableFlow(source, sourceAp, _, _, this, _) and
      source = toCallableFlowSource(tail) and
      head = SummaryComponent::content(sourceAp.getHead()) and
      i = 0
      or
      exists(SummaryComponent tailHead, SummaryComponentStack tailTail |
        this.input(source, sourceAp, tailHead, tailTail, i - 1) and
        head = SummaryComponent::content(sourceAp.drop(i).getHead()) and
        tail = SummaryComponentStack::push(tailHead, tailTail)
      )
    }

    predicate output(
      CallableFlowSink sink, AccessPath sinkAp, SummaryComponent head, SummaryComponentStack tail,
      int i
    ) {
      ltdf.callableFlow(_, _, sink, sinkAp, this, _) and
      sink = toCallableFlowSink(tail) and
      head = SummaryComponent::content(sinkAp.getHead()) and
      i = 0
      or
      exists(SummaryComponent tailHead, SummaryComponentStack tailTail |
        this.output(sink, sinkAp, tailHead, tailTail, i - 1) and
        head = SummaryComponent::content(sinkAp.drop(i).getHead()) and
        tail = SummaryComponentStack::push(tailHead, tailTail)
      )
    }

    override predicate propagatesFlow(
      SummaryComponentStack input, SummaryComponentStack output, boolean preservesValue
    ) {
      ltdf.callableFlow(toCallableFlowSource(input), toCallableFlowSink(output), this,
        preservesValue)
      or
      exists(
        CallableFlowSource source, AccessPath sourceAp, CallableFlowSink sink, AccessPath sinkAp
      |
        ltdf.callableFlow(source, sourceAp, sink, sinkAp, this, preservesValue) and
        (
          exists(SummaryComponent head, SummaryComponentStack tail |
            this.input(source, sourceAp, head, tail, sourceAp.length() - 1) and
            input = SummaryComponentStack::push(head, tail)
          )
          or
          sourceAp.length() = 0 and
          source = toCallableFlowSource(input)
        ) and
        (
          exists(SummaryComponent head, SummaryComponentStack tail |
            this.output(sink, sinkAp, head, tail, sinkAp.length() - 1) and
            output = SummaryComponentStack::push(head, tail)
          )
          or
          sinkAp.length() = 0 and
          sink = toCallableFlowSink(output)
        )
      )
    }

    override predicate clearsContent(ParameterPosition pos, Content content) {
      exists(SummaryComponentStack input |
        ltdf.clearsContent(toCallableFlowSource(input), content, this) and
        input = SummaryComponentStack::argument(pos.getPosition())
      )
    }
  }

  private class AdaptorRequiredSummaryComponentStack extends RequiredSummaryComponentStack {
    private SummaryComponent head;

    AdaptorRequiredSummaryComponentStack() {
      exists(int i |
        exists(TCallableFlowSourceDelegateArg(i)) and
        head = SummaryComponent::return() and
        this = SummaryComponentStack::singleton(SummaryComponent::argument(i))
      )
      or
      exists(int i, int j | exists(TCallableFlowSinkDelegateArg(i, j)) |
        head = SummaryComponent::parameter(j) and
        this = SummaryComponentStack::singleton(SummaryComponent::argument(i))
      )
      or
      exists(FrameworkDataFlowAdaptor adaptor |
        adaptor.input(_, _, head, this, _)
        or
        adaptor.output(_, _, head, this, _)
      )
    }

    override predicate required(SummaryComponent c) { c = head }
  }
}

/** Data flow for `System.Text.StringBuilder`. */
class SystemTextStringBuilderFlow extends LibraryTypeDataFlow, SystemTextStringBuilderClass {
  override predicate clearsContent(
    CallableFlowSource source, Content content, SourceDeclarationCallable callable
  ) {
    source = TCallableFlowSourceQualifier() and
    callable = this.getAMethod("Clear") and
    content instanceof ElementContent
  }
}

/** Data flow for `System.Collections.IEnumerable` (and sub types). */
class IEnumerableFlow extends LibraryTypeDataFlow, RefType {
  IEnumerableFlow() { this.getABaseType*() instanceof SystemCollectionsIEnumerableInterface }

  override predicate callableFlow(
    CallableFlowSource source, AccessPath sourceAp, CallableFlowSink sink, AccessPath sinkAp,
    SourceDeclarationCallable c, boolean preservesValue
  ) {
    preservesValue = true and
    (
      this.methodFlowLINQExtensions(source, sourceAp, sink, sinkAp, c)
      or
      c = this.getFind() and
      sourceAp = AccessPath::element() and
      sinkAp = AccessPath::empty() and
      if c.(Method).isStatic()
      then
        source = TCallableFlowSourceArg(0) and
        (
          sink = TCallableFlowSinkReturn() or
          sink = getDelegateFlowSinkArg(c, 1, 0)
        )
      else (
        source = TCallableFlowSourceQualifier() and
        (
          sink = TCallableFlowSinkReturn() or
          sink = getDelegateFlowSinkArg(c, 0, 0)
        )
      )
      or
      exists(string name, int arity |
        arity = c.getNumberOfParameters() and
        c = this.getAMethod() and
        c.getUndecoratedName() = name
      |
        name = "Add" and
        arity = 1 and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::empty() and
        sink instanceof CallableFlowSinkQualifier and
        sinkAp = AccessPath::element()
        or
        name = "AddRange" and
        arity = 1 and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkQualifier() and
        sinkAp = AccessPath::element()
        or
        exists(Property current |
          name = "GetEnumerator" and
          source = TCallableFlowSourceQualifier() and
          sourceAp = AccessPath::element() and
          sink = TCallableFlowSinkReturn() and
          sinkAp = AccessPath::property(current) and
          current = c.getReturnType().(ValueOrRefType).getProperty("Current")
        )
        or
        name = "Repeat" and
        c.(Method).isStatic() and
        arity = 2 and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::empty() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
        or
        name = "Reverse" and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
      )
    )
  }

  /** Flow for LINQ extension methods. */
  private predicate methodFlowLINQExtensions(
    CallableFlowSource source, AccessPath sourceAp, CallableFlowSink sink, AccessPath sinkAp,
    SourceDeclarationMethod m
  ) {
    m.(ExtensionMethod).getExtendedType().getUnboundDeclaration() = this and
    exists(string name, int arity |
      name = m.getUndecoratedName() and arity = m.getNumberOfParameters()
    |
      name = "Aggregate" and
      (
        arity = 2 and
        (
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 1, 1) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceDelegateArg(1) and
          sourceAp = AccessPath::empty() and
          sink = TCallableFlowSinkReturn() and
          sinkAp = AccessPath::empty()
        )
        or
        arity = 3 and
        (
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 2, 1) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceArg(1) and
          sourceAp = AccessPath::empty() and
          sink = getDelegateFlowSinkArg(m, 2, 0) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceDelegateArg(2) and
          sourceAp = AccessPath::empty() and
          sink = TCallableFlowSinkReturn() and
          sinkAp = AccessPath::empty()
        )
        or
        arity = 4 and
        (
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 2, 1) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceArg(1) and
          sourceAp = AccessPath::empty() and
          sink = getDelegateFlowSinkArg(m, 2, 0) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceDelegateArg(2) and
          sourceAp = AccessPath::empty() and
          sink = getDelegateFlowSinkArg(m, 3, 0) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceDelegateArg(3) and
          sourceAp = AccessPath::empty() and
          sink = TCallableFlowSinkReturn() and
          sinkAp = AccessPath::empty()
        )
      )
      or
      name = "All" and
      arity = 2 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = getDelegateFlowSinkArg(m, 1, 0) and
      sinkAp = AccessPath::empty()
      or
      name = "Any" and
      arity = 2 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = getDelegateFlowSinkArg(m, 1, 0) and
      sinkAp = AccessPath::empty()
      or
      name = "AsEnumerable" and
      arity = 1 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::element()
      or
      name = "AsQueryable" and
      arity = 1 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::element()
      or
      name = "Average" and
      arity = 2 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = getDelegateFlowSinkArg(m, 1, 0) and
      sinkAp = AccessPath::empty()
      or
      name = "Cast" and
      arity = 1 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::element()
      or
      name = "Concat" and
      arity = 2 and
      (
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
        or
        source = TCallableFlowSourceArg(1) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
      )
      or
      name.regexpMatch("(Long)?Count") and
      arity = 2 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = getDelegateFlowSinkArg(m, 1, 0) and
      sinkAp = AccessPath::empty()
      or
      name = "DefaultIfEmpty" and
      (
        arity in [1 .. 2] and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::empty()
        or
        arity = 2 and
        source = TCallableFlowSourceArg(1) and
        sourceAp = AccessPath::empty() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::empty()
      )
      or
      name = "Distinct" and
      arity in [1 .. 2] and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::element()
      or
      name.regexpMatch("ElementAt(OrDefault)?") and
      arity = 2 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::empty()
      or
      name = "Except" and
      arity in [2 .. 3] and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::empty()
      or
      name.regexpMatch("(First|Single)(OrDefault)?") and
      (
        arity in [1 .. 2] and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::empty()
        or
        arity = 2 and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 1, 0) and
        sinkAp = AccessPath::empty()
      )
      or
      name = "GroupBy" and
      (
        arity = 2 and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 1, 0) and
        sinkAp = AccessPath::empty()
        or
        arity = 3 and
        (
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 1, 0) and
          sinkAp = AccessPath::empty()
          or
          m.getParameter(2).getType().(ConstructedDelegateType).getNumberOfTypeArguments() = 2 and
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 2, 0) and
          sinkAp = AccessPath::empty()
          or
          m.getParameter(2).getType().(ConstructedDelegateType).getNumberOfTypeArguments() = 3 and
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::empty() and
          sink = getDelegateFlowSinkArg(m, 2, 1) and
          sinkAp = AccessPath::empty()
          or
          m.getParameter(2).getType().(ConstructedDelegateType).getNumberOfTypeArguments() = 3 and
          source = getDelegateFlowSourceArg(m, 1) and
          sourceAp = AccessPath::empty() and
          sink = getDelegateFlowSinkArg(m, 2, 0) and
          sinkAp = AccessPath::empty()
          or
          not m.getParameter(2).getType().getUnboundDeclaration() instanceof
            SystemCollectionsGenericIEqualityComparerTInterface and
          source = getDelegateFlowSourceArg(m, 2) and
          sourceAp = AccessPath::empty() and
          sink = TCallableFlowSinkReturn() and
          sinkAp = AccessPath::element()
        )
        or
        arity in [4 .. 5] and
        (
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 1, 0) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 2, 0) and
          sinkAp = AccessPath::empty()
          or
          source = getDelegateFlowSourceArg(m, 1) and
          sourceAp = AccessPath::empty() and
          sink = getDelegateFlowSinkArg(m, 2, 0) and
          sinkAp = AccessPath::empty()
          or
          source = getDelegateFlowSourceArg(m, 2) and
          sourceAp = AccessPath::empty() and
          sink = getDelegateFlowSinkArg(m, 3, 1) and
          sinkAp = AccessPath::element()
          or
          source = getDelegateFlowSourceArg(m, 3) and
          sourceAp = AccessPath::empty() and
          sink = TCallableFlowSinkReturn() and
          sinkAp = AccessPath::element()
        )
      )
      or
      name.regexpMatch("(Group)?Join") and
      (
        arity in [5 .. 6] and
        (
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 2, 0) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 4, 0) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceArg(1) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 3, 0) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceArg(1) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 4, 1) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceDelegateArg(4) and
          sourceAp = AccessPath::empty() and
          sink = TCallableFlowSinkReturn() and
          sinkAp = AccessPath::element()
        )
      )
      or
      name = "Intersect" and
      (
        arity in [2 .. 3] and
        (
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = TCallableFlowSinkReturn() and
          sinkAp = AccessPath::element()
          or
          source = TCallableFlowSourceArg(1) and
          sourceAp = AccessPath::element() and
          sink = TCallableFlowSinkReturn() and
          sinkAp = AccessPath::element()
        )
      )
      or
      name.regexpMatch("Last(OrDefault)?") and
      (
        arity in [1 .. 2] and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::empty()
        or
        arity = 2 and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 1, 0) and
        sinkAp = AccessPath::empty()
      )
      or
      name.regexpMatch("Max|Min|Sum") and
      (
        arity = 2 and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 1, 0) and
        sinkAp = AccessPath::empty()
      )
      or
      name = "OfType" and
      arity = 1 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::element()
      or
      name.regexpMatch("OrderBy(Descending)?") and
      arity in [2 .. 3] and
      (
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
        or
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 1, 0) and
        sinkAp = AccessPath::empty()
      )
      or
      name = "Reverse" and
      arity = 1 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::element()
      or
      name.regexpMatch("Select(Many)?") and
      arity = 2 and
      (
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 1, 0) and
        sinkAp = AccessPath::empty()
        or
        source = TCallableFlowSourceDelegateArg(1) and
        sourceAp = AccessPath::empty() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
      )
      or
      name = "SelectMany" and
      arity = 3 and
      (
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 1, 0) and
        sinkAp = AccessPath::empty()
        or
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 2, 0) and
        sinkAp = AccessPath::empty()
        or
        source = TCallableFlowSourceDelegateArg(1) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 2, 1) and
        sinkAp = AccessPath::empty()
        or
        source = TCallableFlowSourceDelegateArg(2) and
        sourceAp = AccessPath::empty() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
      )
      or
      name.regexpMatch("(Skip|Take)(While)?") and
      arity = 2 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::element()
      or
      name.regexpMatch("(Skip|Take)While") and
      arity = 2 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = getDelegateFlowSinkArg(m, 1, 0) and
      sinkAp = AccessPath::empty()
      or
      name.regexpMatch("ThenBy(Descending)?") and
      arity in [2 .. 3] and
      (
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 1, 0) and
        sinkAp = AccessPath::empty()
        or
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
      )
      or
      name.regexpMatch("To(Array|List)") and
      arity = 1 and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::element()
      or
      name.regexpMatch("To(Dictionary|Lookup)") and
      (
        arity in [2 .. 3] and
        (
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 1, 0) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = TCallableFlowSinkReturn() and
          sinkAp = AccessPath::element() and
          not m.getParameter(2).getType() instanceof DelegateType
        )
        or
        arity in [3 .. 4] and
        (
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 1, 0) and
          sinkAp = AccessPath::empty()
          or
          source = TCallableFlowSourceArg(0) and
          sourceAp = AccessPath::element() and
          sink = getDelegateFlowSinkArg(m, 2, 0) and
          sinkAp = AccessPath::empty()
          or
          source = getDelegateFlowSourceArg(m, 2) and
          sourceAp = AccessPath::empty() and
          sink = TCallableFlowSinkReturn() and
          sinkAp = AccessPath::element()
        )
      )
      or
      name = "Union" and
      arity in [2 .. 3] and
      (
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
        or
        source = TCallableFlowSourceArg(1) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
      )
      or
      name = "Where" and
      arity = 2 and
      (
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 1, 0) and
        sinkAp = AccessPath::empty()
        or
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
      )
      or
      name = "Zip" and
      arity = 3 and
      (
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 2, 0) and
        sinkAp = AccessPath::empty()
        or
        source = TCallableFlowSourceArg(1) and
        sourceAp = AccessPath::element() and
        sink = getDelegateFlowSinkArg(m, 2, 1) and
        sinkAp = AccessPath::empty()
        or
        source = getDelegateFlowSourceArg(m, 2) and
        sourceAp = AccessPath::empty() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
      )
    )
  }

  private SourceDeclarationMethod getFind() {
    exists(string name |
      name = result.getUndecoratedName() and
      result.getDeclaringType() = this.getABaseType*()
    |
      name.regexpMatch("Find(All|Last)?")
    )
  }

  override predicate clearsContent(
    CallableFlowSource source, Content content, SourceDeclarationCallable callable
  ) {
    source = TCallableFlowSourceQualifier() and
    callable = this.getAMethod("Clear") and
    content instanceof ElementContent
  }
}

/** Data flow for `System.Collections.[Generic.]ICollection` (and sub types). */
class ICollectionFlow extends LibraryTypeDataFlow, RefType {
  ICollectionFlow() {
    exists(Interface i | i = this.getABaseType*().getUnboundDeclaration() |
      i instanceof SystemCollectionsICollectionInterface
      or
      i instanceof SystemCollectionsGenericICollectionInterface
    )
  }

  override predicate callableFlow(
    CallableFlowSource source, AccessPath sourceAp, CallableFlowSink sink, AccessPath sinkAp,
    SourceDeclarationCallable c, boolean preservesValue
  ) {
    preservesValue = true and
    exists(string name, int arity |
      name = c.getUndecoratedName() and
      arity = c.getNumberOfParameters() and
      c = this.getAMethod()
    |
      name = "CopyTo" and
      arity = 2 and
      source instanceof CallableFlowSourceQualifier and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkArg(0) and
      sinkAp = AccessPath::element()
      or
      name.regexpMatch("AsReadOnly|Clone") and
      source = TCallableFlowSourceArg(0) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::element()
      or
      name.regexpMatch("Peek|Pop") and
      source = TCallableFlowSourceQualifier() and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkReturn() and
      sinkAp = AccessPath::empty()
      or
      name = "InsertRange" and
      arity = 2 and
      source = TCallableFlowSourceArg(1) and
      sourceAp = AccessPath::element() and
      sink = TCallableFlowSinkQualifier() and
      sinkAp = AccessPath::element()
    )
  }
}

/** Data flow for `System.Collections.[Generic.]IList` (and sub types). */
class IListFlow extends LibraryTypeDataFlow, RefType {
  IListFlow() {
    exists(Interface i | i = this.getABaseType*().getUnboundDeclaration() |
      i instanceof SystemCollectionsIListInterface
      or
      i instanceof SystemCollectionsGenericIListInterface
    )
  }

  override predicate callableFlow(
    CallableFlowSource source, AccessPath sourceAp, CallableFlowSink sink, AccessPath sinkAp,
    SourceDeclarationCallable c, boolean preservesValue
  ) {
    preservesValue = true and
    (
      exists(string name, int arity |
        name = c.getName() and
        arity = c.getNumberOfParameters() and
        c = this.getAMethod()
      |
        name = "Insert" and
        arity = 2 and
        source = TCallableFlowSourceArg(1) and
        sourceAp = AccessPath::empty() and
        sink instanceof CallableFlowSinkQualifier and
        sinkAp = AccessPath::element()
        or
        name.regexpMatch("FixedSize|GetRange") and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::element() and
        sink = TCallableFlowSinkReturn() and
        sinkAp = AccessPath::element()
      )
      or
      c = this.getAnIndexer().getSetter() and
      source = TCallableFlowSourceArg(1) and
      sourceAp = AccessPath::empty() and
      sink instanceof CallableFlowSinkQualifier and
      sinkAp = AccessPath::element()
      or
      c = this.getAnIndexer().getGetter() and
      source instanceof CallableFlowSourceQualifier and
      sourceAp = AccessPath::element() and
      sink instanceof CallableFlowSinkReturn and
      sinkAp = AccessPath::empty()
    )
  }
}

/** Data flow for `System.Collections.[Generic.]IDictionary` (and sub types). */
class IDictionaryFlow extends LibraryTypeDataFlow, RefType {
  IDictionaryFlow() {
    exists(Interface i | i = this.getABaseType*().getUnboundDeclaration() |
      i instanceof SystemCollectionsIDictionaryInterface
      or
      i instanceof SystemCollectionsGenericIDictionaryInterface
    )
  }

  override predicate callableFlow(
    CallableFlowSource source, AccessPath sourceAp, CallableFlowSink sink, AccessPath sinkAp,
    SourceDeclarationCallable c, boolean preservesValue
  ) {
    preservesValue = true and
    exists(SystemCollectionsGenericKeyValuePairStruct kvp |
      exists(int i |
        c = this.getAConstructor() and
        source = TCallableFlowSourceArg(i) and
        sourceAp = sinkAp and
        c.getParameter(i).getType().(ValueOrRefType).getABaseType*() instanceof
          SystemCollectionsIEnumerableInterface and
        sink instanceof CallableFlowSinkReturn
      |
        sinkAp = AccessPath::properties(kvp.getKeyProperty())
        or
        sinkAp = AccessPath::properties(kvp.getValueProperty())
      )
      or
      c = this.getProperty("Keys").getGetter() and
      source instanceof CallableFlowSourceQualifier and
      sourceAp = AccessPath::properties(kvp.getKeyProperty()) and
      sink instanceof CallableFlowSinkReturn and
      sinkAp = AccessPath::element()
      or
      (
        c = this.getProperty("Values").getGetter()
        or
        c = this.getAMethod("GetValueList")
      ) and
      source instanceof CallableFlowSourceQualifier and
      sourceAp = AccessPath::properties(kvp.getValueProperty()) and
      sink instanceof CallableFlowSinkReturn and
      sinkAp = AccessPath::element()
      or
      (
        c = this.getAMethod("Add") and
        c.getNumberOfParameters() = 2
        or
        c = this.getAnIndexer().getSetter()
      ) and
      (
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::empty() and
        sink instanceof CallableFlowSinkQualifier and
        sinkAp = AccessPath::properties(kvp.getKeyProperty())
        or
        source = TCallableFlowSourceArg(1) and
        sourceAp = AccessPath::empty() and
        sink instanceof CallableFlowSinkQualifier and
        sinkAp = AccessPath::properties(kvp.getValueProperty())
      )
      or
      exists(Property p |
        c = this.getAMethod("Add") and
        c.getNumberOfParameters() = 1 and
        source = TCallableFlowSourceArg(0) and
        sourceAp = AccessPath::property(p) and
        sink instanceof CallableFlowSinkQualifier and
        sinkAp = AccessPath::properties(p) and
        p = kvp.getAProperty()
      )
      or
      (
        c = this.getAnIndexer().getGetter()
        or
        c = this.getAMethod("GetByIndex")
      ) and
      source instanceof CallableFlowSourceQualifier and
      sourceAp = AccessPath::properties(kvp.getValueProperty()) and
      sink instanceof CallableFlowSinkReturn and
      sinkAp = AccessPath::empty()
    )
  }
}

abstract private class SyntheticTaskField extends SyntheticField {
  bindingset[this]
  SyntheticTaskField() { any() }

  override Type getType() { result instanceof SystemThreadingTasksTaskTClass }
}

private class SyntheticTaskAwaiterUnderlyingTaskField extends SyntheticTaskField {
  SyntheticTaskAwaiterUnderlyingTaskField() { this = "m_task_task_awaiter" }
}

private class SyntheticConfiguredTaskAwaitableUnderlyingTaskField extends SyntheticTaskField {
  SyntheticConfiguredTaskAwaitableUnderlyingTaskField() {
    this = "m_task_configured_task_awaitable"
  }
}

private class SyntheticConfiguredTaskAwaiterField extends SyntheticField {
  SyntheticConfiguredTaskAwaiterField() { this = "m_configuredTaskAwaiter" }

  override Type getType() {
    result instanceof
      SystemRuntimeCompilerServicesConfiguredTaskAwaitableTConfiguredTaskAwaiterStruct
  }
}

/**
 * Custom flow through `StringValues` library class.
 */
class StringValuesFlow extends LibraryTypeDataFlow, Struct {
  StringValuesFlow() { this.hasQualifiedName("Microsoft.Extensions.Primitives", "StringValues") }

  override predicate callableFlow(
    CallableFlowSource source, CallableFlowSink sink, SourceDeclarationCallable c,
    boolean preservesValue
  ) {
    c.getDeclaringType() = this and
    (
      source instanceof CallableFlowSourceArg or
      source instanceof CallableFlowSourceQualifier
    ) and
    sink instanceof CallableFlowSinkReturn and
    preservesValue = false
  }
}

private predicate recordConstructorFlow(Constructor c, int i, Property p) {
  c = any(Record r).getAMember() and
  exists(string name |
    c.getParameter(i).getName() = name and
    c.getDeclaringType().getAMember(name) = p
  )
}

private class RecordConstructorFlowRequiredSummaryComponentStack extends RequiredSummaryComponentStack {
  private SummaryComponent head;

  RecordConstructorFlowRequiredSummaryComponentStack() {
    exists(Property p |
      recordConstructorFlow(_, _, p) and
      head = SummaryComponent::property(p) and
      this = SummaryComponentStack::singleton(SummaryComponent::return())
    )
  }

  override predicate required(SummaryComponent c) { c = head }
}

private class RecordConstructorFlow extends SummarizedCallable {
  RecordConstructorFlow() { recordConstructorFlow(this, _, _) }

  override predicate propagatesFlow(
    SummaryComponentStack input, SummaryComponentStack output, boolean preservesValue
  ) {
    exists(int i, Property p |
      recordConstructorFlow(this, i, p) and
      input = SummaryComponentStack::argument(i) and
      output = SummaryComponentStack::propertyOf(p, SummaryComponentStack::return()) and
      preservesValue = true
    )
  }
}
