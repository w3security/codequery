﻿using Microsoft.CodeAnalysis;
using System.Linq;

namespace Semmle.Extraction
{
    /// <summary>
    /// Defines which entities belong in the trap file
    /// for the currently extracted entity. This is used to ensure that
    /// trap files do not contain redundant information. Generally a symbol
    /// should have an affinity with exactly one trap file, except for constructed
    /// symbols.
    /// </summary>
    public interface IExtractionScope
    {
        /// <summary>
        /// Whether the given symbol belongs in the trap file.
        /// </summary>
        /// <param name="symbol">The symbol to populate.</param>
        bool InScope(ISymbol symbol);

        /// <summary>
        /// Whether the given file belongs in the trap file.
        /// </summary>
        /// <param name="path">The path to populate.</param>
        bool InFileScope(string path);
    }

    /// <summary>
    /// The scope of symbols in an assembly.
    /// </summary>
    public class AssemblyScope : IExtractionScope
    {
        readonly IAssemblySymbol assembly;
        readonly string filepath;

        public AssemblyScope(IAssemblySymbol symbol, string path)
        {
            assembly = symbol;
            filepath = path;
        }

        public bool InFileScope(string path) => path == filepath;

        public bool InScope(ISymbol symbol) => Equals(symbol.ContainingAssembly, assembly);
    }

    /// <summary>
    /// The scope of symbols in a source file.
    /// </summary>
    public class SourceScope : IExtractionScope
    {
        readonly SyntaxTree sourceTree;

        public SourceScope(SyntaxTree tree)
        {
            sourceTree = tree;
        }

        public bool InFileScope(string path) => path == sourceTree.FilePath;

        public bool InScope(ISymbol symbol) => symbol.Locations.Any(loc => loc.SourceTree == sourceTree);
    }
}
