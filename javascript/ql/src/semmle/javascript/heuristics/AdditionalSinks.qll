/**
 * Provides classes that heuristically increase the extent of the sinks in security queries.
 *
 * Note: This module should not be a permanent part of the standard library imports.
 */

import javascript
private import SyntacticHeuristics
private import semmle.javascript.security.dataflow.CodeInjection
private import semmle.javascript.security.dataflow.CommandInjection
private import semmle.javascript.security.dataflow.DomBasedXss as DomBasedXss
private import semmle.javascript.security.dataflow.ReflectedXss as ReflectedXss
private import semmle.javascript.security.dataflow.SqlInjection
private import semmle.javascript.security.dataflow.NosqlInjection
private import semmle.javascript.security.dataflow.TaintedPath
private import semmle.javascript.security.dataflow.RegExpInjection
private import semmle.javascript.security.dataflow.ClientSideUrlRedirect
private import semmle.javascript.security.dataflow.ServerSideUrlRedirect
private import semmle.javascript.security.dataflow.InsecureRandomness

/**
 * A heuristic sink for data flow in a security query.
 */
abstract class HeuristicSink extends DataFlow::Node { }

private class HeuristicCodeInjectionSink extends HeuristicSink, CodeInjection::Sink {
  HeuristicCodeInjectionSink() {
    isAssignedToOrConcatenatedWith(this, "(?i)(command|cmd|exec|code|script|program)") or
    isArgTo(this, "(?i)(eval|run)") or // "exec" clashes too often with `RegExp.prototype.exec`
    exists (string srcPattern |
      // function/lambda syntax anywhere
      srcPattern = "(?s).*function\\s*\\(.*\\).*" or
      srcPattern = "(?s).*(\\(.*\\)|[A-Za-z_]+)\\s?=>.*" |
      isContatenatedWithString(this, srcPattern)
    ) or
    // dynamic property name
    isContatenatedWithStrings("(?is)[a-z]+\\[", this, "(?s)\\].*")
  }
}

private class HeuristicCommandInjectionSink extends HeuristicSink, CommandInjection::Sink {
  HeuristicCommandInjectionSink() {
    isAssignedToOrConcatenatedWith(this, "(?i)(command|cmd|exec|code|script|program)") or
    isArgTo(this, "(?i)(a?sync)?(eval|run)(a?sync)?") // "exec" clashes too often with `RegExp.prototype.exec`
  }
}
private class HeuristicDomBasedXssSink extends HeuristicSink, DomBasedXss::DomBasedXss::Sink {
  HeuristicDomBasedXssSink() {
    isAssignedToOrConcatenatedWith(this, "(?i)(html|innerhtml)") or
    isArgTo(this, "(?i)(html|render)") or
    isContatenatedWithString(this, "(?is).*<.*>.*") or
    isContatenatedWithStrings("(?is).*<[a-z ]+.*", this, "(?s).*>.*")
  }
}

private class HeuristicReflectedXssSink extends HeuristicSink, ReflectedXss::ReflectedXss::Sink {
  HeuristicReflectedXssSink() {
    isAssignedToOrConcatenatedWith(this, "(?i)(html|innerhtml)") or
    isArgTo(this, "(?i)(html|render)") or
    isContatenatedWithString(this, "(?is).*<.*>.*") or
    isContatenatedWithStrings("(?is).*<[a-z ]+.*", this, "(?s).*>.*")
  }
}

private class HeuristicSqlInjectionSink extends HeuristicSink, SqlInjection::Sink {
  HeuristicSqlInjectionSink() {
    isAssignedToOrConcatenatedWith(this, "(?i)(sql|query)") or
    isArgTo(this, "(?i)(query)") or
    isContatenatedWithString(this, "(?s).*(ALTER|COUNT|CREATE|DATABASE|DELETE|DISTINCT|DROP|FROM|GROUP|INSERT|INTO|LIMIT|ORDER|SELECT|TABLE|UPDATE|WHERE).*")
  }
}

private class HeuristicNosqlInjectionSink extends HeuristicSink, NosqlInjection::Sink {
  HeuristicNosqlInjectionSink() {
    isAssignedToOrConcatenatedWith(this, "(?i)(nosql|query)") or
    isArgTo(this, "(?i)(query)")
  }
}

private class HeuristicTaintedPathSink extends HeuristicSink, TaintedPath::Sink {
  HeuristicTaintedPathSink() {
    isAssignedToOrConcatenatedWith(this, "(?i)(file|folder|dir|absolute)") or // "path" is too noisy in practice
    isArgTo(this, "(?i)(get|read)file") or
    exists (string pathPattern |
      // paths with at least two parts, and either a trailing or leading slash
      pathPattern = "(?i)([a-z0-9_.-]+/){2,}" or
      pathPattern = "(?i)(/[a-z0-9_.-]+){2,}" |
      isContatenatedWithString(this, pathPattern)
    ) or
    isContatenatedWithStrings(".*/", this, "/.*")
  }
}

private class HeuristicRegexpInjectionSink extends HeuristicSink, RegExpInjection::Sink {
  HeuristicRegexpInjectionSink() {
    isAssignedToOrConcatenatedWith(this, "(?i)(regexp?)") or
    isArgTo(this, "(?i)(match)")
  }
}

private class HeuristicClientSideUrlRedirectSink extends HeuristicSink, ClientSideUrlRedirect::Sink {
  HeuristicClientSideUrlRedirectSink() {
    isAssignedToOrConcatenatedWith(this, "(?i)(redirect)") or
    isArgTo(this, "(?i)(redirect)")
  }
}

private class HeuristicServerSideUrlRedirectSink extends HeuristicSink, ServerSideUrlRedirect::Sink {
  HeuristicServerSideUrlRedirectSink() {
    isAssignedToOrConcatenatedWith(this, "(?i)(redirect)") or
    isArgTo(this, "(?i)(redirect)")
  }
}

private class HeuristicInsecureRandomTokenSink extends HeuristicSink, InsecureRandomness::Sink {

  HeuristicInsecureRandomTokenSink() {
    isAssignedToOrConcatenatedWith(this, "(?i)(token|csrf|unique)")
  }

}