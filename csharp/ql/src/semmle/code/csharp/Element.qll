/**
 * Provides the `Element` class, the base class of all C# program elements.
 */

import Location
import Member
private import semmle.code.csharp.ExprOrStmtParent
private import dotnet

/**
 * A program element. Either a control flow element (`ControlFlowElement`), an
 * attribute (`Attribute`), a declaration (`Declaration`), a modifier
 * (`Modifier`), a namespace (`Namespace`), a namespace declaration
 * (`NamespaceDeclaration`), a `using` directive (`UsingDirective`), or type
 * parameter constraints (`TypeParameterConstraints`).
 */
class Element extends DotNet::Element, @element {
  override string toStringWithTypes() { result = this.toString() }

  /**
   * Gets the location of this element, if any.
   * Where an element has multiple locations (for example a source file and an assembly),
   * gets only the source location.
   */
  override Location getLocation() { result = ExprOrStmtParentCached::bestLocation(this) }

  /** Gets a location of this element, including sources and assemblies. */
  override Location getALocation() { none() }

  override File getFile() { result = getLocation().getFile() }

  override predicate fromSource() { this.getFile().fromSource() }

  /** Holds if this element is from an assembly. */
  predicate fromLibrary() { this.getFile().fromLibrary() }

  /** Gets the parent of this element, if any. */
  Element getParent() { result.getAChild() = this }

  /** Gets a child of this element, if any. */
  Element getAChild() { result = getChild(_) }

  /** Gets the `i`th child of this element (zero-based). */
  Element getChild(int i) { none() }

  /** Gets the number of children of this element. */
  pragma[nomagic]
  int getNumberOfChildren() { result = count(int i | exists(this.getChild(i))) }

  /**
   * Gets the index of this element among its parent's
   * other children (zero-based).
   */
  int getIndex() { exists(Element parent | parent.getChild(result) = this) }
}
