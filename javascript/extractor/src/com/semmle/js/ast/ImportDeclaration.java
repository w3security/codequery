package com.semmle.js.ast;

import java.util.List;

/**
 * An import declaration, which can be of one of the following forms:
 *
 * <pre>
 *   import v from "m";
 *   import * as ns from "m";
 *   import {x, y, w as z} from "m";
 *   import v, * as ns from "m";
 *   import v, {x, y, w as z} from "m";
 *   import "m";
 * </pre>
 */
public class ImportDeclaration extends Statement {
  /** List of import specifiers detailing how declarations are imported; may be empty. */
  private final List<ImportSpecifier> specifiers;

  /** The module from which declarations are imported. */
  private final Literal source;

  public ImportDeclaration(SourceLocation loc, List<ImportSpecifier> specifiers, Literal source) {
    super("ImportDeclaration", loc);
    this.specifiers = specifiers;
    this.source = source;
  }

  public Literal getSource() {
    return source;
  }

  public List<ImportSpecifier> getSpecifiers() {
    return specifiers;
  }

  @Override
  public <C, R> R accept(Visitor<C, R> v, C c) {
    return v.visit(this, c);
  }
}
