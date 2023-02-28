import semmle.code.cpp.models.interfaces.Taint

/**
 * The `std::basic_string` template class.
 */
class StdBasicString extends TemplateClass {
  StdBasicString() { this.hasQualifiedName("std", "basic_string") }
}

/**
 * The `std::string` function `c_str`.
 */
class StdStringCStr extends TaintFunction {
  StdStringCStr() { this.hasQualifiedName("std", "basic_string", "c_str") }

  override predicate hasTaintFlow(FunctionInput input, FunctionOutput output) {
    // flow from string itself (qualifier) to return value
    input.isQualifierObject() and
    output.isReturnValueDeref()
  }
}

/**
 * The `std::string` function `data`.
 */
class StdStringData extends TaintFunction {
  StdStringData() { this.hasQualifiedName("std", "basic_string", "data") }

  override predicate hasTaintFlow(FunctionInput input, FunctionOutput output) {
    // flow from string itself (qualifier) to return value
    input.isQualifierObject() and
    output.isReturnValueDeref()
    or
    // reverse flow from returned reference to the qualifier (for writes to
    // `data`)
    input.isReturnValueDeref() and
    output.isQualifierObject()
  }
}

/**
 * The `std::string` function `operator+`.
 */
class StdStringPlus extends TaintFunction {
  StdStringPlus() {
    this.hasQualifiedName("std", "operator+") and
    this.getUnspecifiedType() = any(StdBasicString s).getAnInstantiation()
  }

  override predicate hasTaintFlow(FunctionInput input, FunctionOutput output) {
    // flow from parameters to return value
    (
      input.isParameterDeref(0) or
      input.isParameterDeref(1)
    ) and
    output.isReturnValue()
  }
}

/**
 * The `std::string` functions `operator+=`, `append`, `insert` and
 * `replace`. All of these functions combine the existing string
 * with a new string (or character) from one of the arguments.
 */
class StdStringAppend extends TaintFunction {
  StdStringAppend() {
    this.hasQualifiedName("std", "basic_string", ["operator+=", "append", "insert", "replace"])
  }

  /**
   * Gets the index of a parameter to this function that is a string (or
   * character).
   */
  int getAStringParameterIndex() {
    getParameter(result).getType() instanceof PointerType or
    getParameter(result).getType() instanceof ReferenceType or
    getParameter(result).getUnspecifiedType() =
      getDeclaringType().getTemplateArgument(0).(Type).getUnspecifiedType() // i.e. `std::basic_string::CharT`
  }

  override predicate hasTaintFlow(FunctionInput input, FunctionOutput output) {
    // flow from string and parameter to string (qualifier) and return value
    (
      input.isQualifierObject() or
      input.isParameterDeref(getAStringParameterIndex())
    ) and
    (
      output.isQualifierObject() or
      output.isReturnValueDeref()
    )
  }
}

/**
 * The standard function `std::string.assign`.
 */
class StdStringAssign extends TaintFunction {
  StdStringAssign() { this.hasQualifiedName("std", "basic_string", "assign") }

  /**
   * Gets the index of a parameter to this function that is a string (or
   * character).
   */
  int getAStringParameterIndex() {
    getParameter(result).getType() instanceof PointerType or
    getParameter(result).getType() instanceof ReferenceType or
    getParameter(result).getUnspecifiedType() =
      getDeclaringType().getTemplateArgument(0).(Type).getUnspecifiedType() // i.e. `std::basic_string::CharT`
  }

  override predicate hasTaintFlow(FunctionInput input, FunctionOutput output) {
    // flow from parameter to string itself (qualifier) and return value
    input.isParameterDeref(getAStringParameterIndex()) and
    (
      output.isQualifierObject() or
      output.isReturnValueDeref()
    )
  }
}

/**
 * The standard function `std::string.copy`.
 */
class StdStringCopy extends TaintFunction {
  StdStringCopy() { this.hasQualifiedName("std", "basic_string", "copy") }

  override predicate hasTaintFlow(FunctionInput input, FunctionOutput output) {
    // copy(dest, num, pos)
    input.isQualifierObject() and
    output.isParameterDeref(0)
  }
}

/**
 * The standard function `std::string.substr`.
 */
class StdStringSubstr extends TaintFunction {
  StdStringSubstr() { this.hasQualifiedName("std", "basic_string", "substr") }

  override predicate hasTaintFlow(FunctionInput input, FunctionOutput output) {
    // substr(pos, num)
    input.isQualifierObject() and
    output.isReturnValue()
  }
}

/**
 * The standard function `std::string.swap`.
 */
class StdStringSwap extends TaintFunction {
  StdStringSwap() { this.hasQualifiedName("std", "basic_string", "swap") }

  override predicate hasTaintFlow(FunctionInput input, FunctionOutput output) {
    // str1.swap(str2)
    input.isQualifierObject() and
    output.isParameterDeref(0)
    or
    input.isParameterDeref(0) and
    output.isQualifierObject()
  }
}

/**
 * The `std::string` functions `at` and `operator[]`.
 */
class StdStringAt extends TaintFunction {
  StdStringAt() { this.hasQualifiedName("std", "basic_string", ["at", "operator[]"]) }

  override predicate hasTaintFlow(FunctionInput input, FunctionOutput output) {
    // flow from qualifier to referenced return value
    input.isQualifierObject() and
    output.isReturnValueDeref()
    or
    // reverse flow from returned reference to the qualifier
    input.isReturnValueDeref() and
    output.isQualifierObject()
  }
}
