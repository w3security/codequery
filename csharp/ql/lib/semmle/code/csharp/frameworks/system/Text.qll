/** Provides definitions related to the namespace `System.Text`. */

import csharp
private import semmle.code.csharp.frameworks.System
private import semmle.code.csharp.dataflow.ExternalFlow

/** The `System.Text` namespace. */
class SystemTextNamespace extends Namespace {
  SystemTextNamespace() {
    this.getParentNamespace() instanceof SystemNamespace and
    this.hasName("Text")
  }
}

/** A class in the `System.Text` namespace. */
class SystemTextClass extends Class {
  SystemTextClass() { this.getNamespace() instanceof SystemTextNamespace }
}

/** The `System.Text.StringBuilder` class. */
class SystemTextStringBuilderClass extends SystemTextClass {
  SystemTextStringBuilderClass() { this.hasName("StringBuilder") }

  /** Gets the `AppendFormat` method. */
  Method getAppendFormatMethod() { result = this.getAMethod("AppendFormat") }
}

/** Data flow for `System.Text.StringBuilder`. */
private class SystemTextStringBuilderFlowModelCsv extends SummaryModelCsv {
  override predicate row(string row) {
    row =
      [
        "System.Text;StringBuilder;false;Append;(System.Boolean);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Byte);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Char);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Char*,System.Int32);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Char,System.Int32);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Char[]);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Char[]);;Element of Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;Append;(System.Char[],System.Int32,System.Int32);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Char[],System.Int32,System.Int32);;Element of Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;Append;(System.Decimal);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Double);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Int16);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Int32);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Int64);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Object);;Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;Append;(System.Object);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.ReadOnlyMemory<System.Char>);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.ReadOnlySpan<System.Char>);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.SByte);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Single);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.String);;Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;Append;(System.String);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.String,System.Int32,System.Int32);;Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;Append;(System.String,System.Int32,System.Int32);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Text.StringBuilder);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.Text.StringBuilder,System.Int32,System.Int32);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.UInt16);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.UInt32);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;Append;(System.UInt64);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object);;Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object);;Argument[2];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object,System.Object);;Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object,System.Object);;Argument[2];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object,System.Object);;Argument[3];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object,System.Object);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object,System.Object,System.Object);;Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object,System.Object,System.Object);;Argument[2];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object,System.Object,System.Object);;Argument[3];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object,System.Object,System.Object);;Argument[4];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object,System.Object,System.Object);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object[]);;Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object[]);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendFormat;(System.IFormatProvider,System.String,System.Object[]);;Element of Argument[2];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object);;Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object);;Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object,System.Object);;Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object,System.Object);;Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object,System.Object);;Argument[2];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object,System.Object);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object,System.Object,System.Object);;Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object,System.Object,System.Object);;Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object,System.Object,System.Object);;Argument[2];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object,System.Object,System.Object);;Argument[3];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object,System.Object,System.Object);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object[]);;Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object[]);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendFormat;(System.String,System.Object[]);;Element of Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendJoin;(System.Char,System.Object[]);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendJoin;(System.Char,System.Object[]);;Element of Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendJoin;(System.Char,System.String[]);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendJoin;(System.Char,System.String[]);;Element of Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendJoin;(System.String,System.Object[]);;Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendJoin;(System.String,System.Object[]);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendJoin;(System.String,System.Object[]);;Element of Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendJoin;(System.String,System.String[]);;Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendJoin;(System.String,System.String[]);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendJoin;(System.String,System.String[]);;Element of Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendJoin<>;(System.Char,System.Collections.Generic.IEnumerable<T>);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendJoin<>;(System.Char,System.Collections.Generic.IEnumerable<T>);;Element of Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendJoin<>;(System.String,System.Collections.Generic.IEnumerable<T>);;Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendJoin<>;(System.String,System.Collections.Generic.IEnumerable<T>);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendJoin<>;(System.String,System.Collections.Generic.IEnumerable<T>);;Element of Argument[1];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendLine;();;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;AppendLine;(System.String);;Argument[0];Element of Argument[-1];value",
        "System.Text;StringBuilder;false;AppendLine;(System.String);;Argument[-1];ReturnValue;value",
        "System.Text;StringBuilder;false;StringBuilder;(System.String);;Argument[0];Element of ReturnValue;value",
        "System.Text;StringBuilder;false;StringBuilder;(System.String,System.Int32);;Argument[0];Element of ReturnValue;value",
        "System.Text;StringBuilder;false;StringBuilder;(System.String,System.Int32,System.Int32,System.Int32);;Argument[0];Element of ReturnValue;value",
        "System.Text;StringBuilder;false;ToString;();;Element of Argument[-1];ReturnValue;taint",
        "System.Text;StringBuilder;false;ToString;(System.Int32,System.Int32);;Element of Argument[-1];ReturnValue;taint",
      ]
  }
}

/** The `System.Text.Encoding` class. */
class SystemTextEncodingClass extends SystemTextClass {
  SystemTextEncodingClass() { this.hasName("Encoding") }

  /** Gets the `GetBytes` method. */
  Method getGetBytesMethod() { result = this.getAMethod("GetBytes") }

  /** Gets the `GetString` method. */
  Method getGetStringMethod() { result = this.getAMethod("GetString") }

  /** Gets the `GetChars` method. */
  Method getGetCharsMethod() { result = this.getAMethod("GetChars") }
}

/** Data flow for `System.Text.Encoding`. */
private class SystemTextEncodingFlowModelCsv extends SummaryModelCsv {
  override predicate row(string row) {
    row =
      [
        "System.Text;Encoding;false;GetBytes;(System.String,System.Int32,System.Int32);;Argument[0];ReturnValue;taint",
        "System.Text;Encoding;false;GetString;(System.Byte*,System.Int32);;Element of Argument[0];ReturnValue;taint",
        "System.Text;Encoding;false;GetString;(System.ReadOnlySpan<System.Byte>);;Element of Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetBytes;(System.Char*,System.Int32,System.Byte*,System.Int32);;Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetBytes;(System.Char[]);;Element of Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetBytes;(System.Char[],System.Int32,System.Int32);;Element of Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetBytes;(System.Char[],System.Int32,System.Int32,System.Byte[],System.Int32);;Element of Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetBytes;(System.ReadOnlySpan<System.Char>,System.Span<System.Byte>);;Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetBytes;(System.String);;Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetBytes;(System.String,System.Int32,System.Int32,System.Byte[],System.Int32);;Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetChars;(System.Byte*,System.Int32,System.Char*,System.Int32);;Element of Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetChars;(System.Byte[]);;Element of Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetChars;(System.Byte[],System.Int32,System.Int32);;Element of Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetChars;(System.Byte[],System.Int32,System.Int32,System.Char[],System.Int32);;Element of Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetChars;(System.ReadOnlySpan<System.Byte>,System.Span<System.Char>);;Element of Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetString;(System.Byte[]);;Element of Argument[0];ReturnValue;taint",
        "System.Text;Encoding;true;GetString;(System.Byte[],System.Int32,System.Int32);;Element of Argument[0];ReturnValue;taint",
      ]
  }
}
