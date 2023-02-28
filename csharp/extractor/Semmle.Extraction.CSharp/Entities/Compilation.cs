﻿using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Semmle.Extraction.CSharp.Entities
{
    class Compilation : FreshEntity
    {
        public Compilation(Context cx, string cwd, string[] args) : base(cx)
        {
            Extraction.Entities.Assembly.CreateOutputAssembly(cx);

            cx.Emit(Tuples.compilations(this, Extraction.Entities.File.PathAsDatabaseString(cwd)));

            // Arguments
            int index = 0;
            foreach(var arg in args)
            {
                cx.Emit(Tuples.compilation_args(this, index++, arg));
            }

            // Files
            index = 0;
            foreach(var file in cx.Compilation.SyntaxTrees.Select(tree => Extraction.Entities.File.Create(cx, tree.FilePath)))
            {
                cx.Emit(Tuples.compilation_compiling_files(this, index++, file));
            }

            // References
            index = 0;
            foreach(var file in cx.Compilation.References.OfType<PortableExecutableReference>().Select(r => Extraction.Entities.File.Create(cx, r.FilePath)))
            {
                cx.Emit(Tuples.compilation_referencing_files(this, index++, file));
            }

            // Diagnostics
            index = 0;
            foreach(var diag in cx.Compilation.GetDiagnostics().Select(d => new Diagnostic(cx, d)))
            {
                cx.Emit(Tuples.diagnostic_for(diag, this, 0, index++));
            }
        }

        public void PopulatePerformance(PerformanceMetrics p)
        {
            int index = 0;
            foreach(float metric in p.Metrics)
            {
                cx.Emit(Tuples.compilation_time(this, -1, index++, metric));
            }
            cx.Emit(Tuples.compilation_finished(this, (float)p.Total.Cpu.TotalSeconds, (float)p.Total.Elapsed.TotalSeconds));
        }

        public override TrapStackBehaviour TrapStackBehaviour => TrapStackBehaviour.NoLabel;
    }

    class Diagnostic : FreshEntity
    {
        public override TrapStackBehaviour TrapStackBehaviour => TrapStackBehaviour.NoLabel;

        public Diagnostic(Context cx, Microsoft.CodeAnalysis.Diagnostic diag) : base(cx)
        {
            cx.Emit(Tuples.diagnostics(this, (int)diag.Severity, diag.Id, diag.Descriptor.Title.ToString(),
                diag.GetMessage(), Extraction.Entities.Location.Create(cx, diag.Location)));
        }
    }

    public struct Timings
    {
        public TimeSpan Elapsed, Cpu, User;
    }

    /// <summary>
    /// The various performance metrics to log.
    /// </summary>
    public struct PerformanceMetrics
    {
        public Timings Frontend, Extractor, Total;
        public long PeakWorkingSet;

        /// <summary>
        /// These are in database order (0 indexed)
        /// </summary>
        public IEnumerable<float> Metrics
        {
            get
            {
                yield return (float)Frontend.Cpu.TotalSeconds;
                yield return (float)Frontend.Elapsed.TotalSeconds;
                yield return (float)Extractor.Cpu.TotalSeconds;
                yield return (float)Extractor.Elapsed.TotalSeconds;
                yield return (float)Frontend.User.TotalSeconds;
                yield return (float)Extractor.User.TotalSeconds;
                yield return PeakWorkingSet / 1024.0f / 1024.0f;
            }
        }
    }
}
