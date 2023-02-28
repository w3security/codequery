﻿using System.Reflection;
using System.Globalization;
using System.Collections.Generic;
using Semmle.Util.Logging;
using System;

namespace Semmle.Extraction.CIL.Entities
{
    public interface ILocation : IEntity
    {
    }

    interface IAssembly : ILocation
    {
    }

    /// <summary>
    /// An assembly to extract.
    /// </summary>
    public class Assembly : LabelledEntity, IAssembly
    {
        public override Id IdSuffix => suffix;

        readonly File file;
        readonly AssemblyName assemblyName;

        public Assembly(Context cx) : base(cx)
        {
            cx.assembly = this;
            var def = cx.mdReader.GetAssemblyDefinition();

            assemblyName = new AssemblyName();
            assemblyName.Name = cx.mdReader.GetString(def.Name);
            assemblyName.Version = def.Version;
            assemblyName.CultureInfo = new CultureInfo(cx.mdReader.GetString(def.Culture));

            if (!def.PublicKey.IsNil)
                assemblyName.SetPublicKey(cx.mdReader.GetBlobBytes(def.PublicKey));

            ShortId = cx.GetId(assemblyName.FullName) + "#file:///" + cx.assemblyPath.Replace("\\", "/");

            file = new File(cx, cx.assemblyPath);
        }

        static readonly Id suffix = new StringId(";assembly");

        public override IEnumerable<IExtractionProduct> Contents
        {
            get
            {
                yield return file;
                yield return Tuples.assemblies(this, file, assemblyName.FullName, assemblyName.Name, assemblyName.Version.ToString());

                if (cx.pdb != null)
                {
                    foreach (var f in cx.pdb.SourceFiles)
                    {
                        yield return cx.CreateSourceFile(f);
                    }
                }

                foreach (var handle in cx.mdReader.TypeDefinitions)
                {
                    IExtractionProduct product = null;
                    try
                    {
                        product = cx.Create(handle);
                    }
                    catch (InternalError e)
                    {
                        cx.cx.Extractor.Message(new Message
                        {
                            exception = e,
                            message = "Error processing type definition",
                            severity = Semmle.Util.Logging.Severity.Error
                        });
                    }

                    // Limitation of C#: Cannot yield return inside a try-catch.
                    if (product != null)
                        yield return product;
                }

                foreach (var handle in cx.mdReader.MethodDefinitions)
                {
                    IExtractionProduct product = null;
                    try
                    {
                        product = cx.Create(handle);
                    }
                    catch (InternalError e)
                    {
                        cx.cx.Extractor.Message(new Message
                        {
                            exception = e,
                            message = "Error processing bytecode",
                            severity = Semmle.Util.Logging.Severity.Error
                        });
                    }

                    if (product != null)
                        yield return product;
                }
            }
        }

        static void ExtractCIL(Extraction.Context cx, string assemblyPath, bool extractPdbs)
        {
            using (var cilContext = new Context(cx, assemblyPath, extractPdbs))
            {
                cilContext.Populate(new Assembly(cilContext));
                cilContext.cx.PopulateAll();
            }
        }

        /// <summary>
        /// Main entry point to the CIL extractor.
        /// Call this to extract a given assembly.
        /// </summary>
        /// <param name="layout">The trap layout.</param>
        /// <param name="assemblyPath">The full path of the assembly to extract.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="nocache">True to overwrite existing trap file.</param>
        /// <param name="extractPdbs">Whether to extract PDBs.</param>
        /// <param name="trapFile">The path of the trap file.</param>
        /// <param name="extracted">Whether the file was extracted (false=cached).</param>
        public static void ExtractCIL(Layout layout, string assemblyPath, ILogger logger, bool nocache, bool extractPdbs, out string trapFile, out bool extracted)
        {
            trapFile = "";
            extracted = false;
            try
            {
                var extractor = new Extractor(false, assemblyPath, logger);
                var project = layout.LookupProjectOrDefault(assemblyPath);
                using (var trapWriter = project.CreateTrapWriter(logger, assemblyPath + ".cil", true))
                {
                    trapFile = trapWriter.TrapFile;
                    if (nocache || !System.IO.File.Exists(trapFile))
                    {
                        var cx = new Extraction.Context(extractor, null, trapWriter, null);
                        ExtractCIL(cx, assemblyPath, extractPdbs);
                        extracted = true;
                    }
                }
            }
            catch (Exception ex)  // lgtm[cs/catch-of-all-exceptions]
            {
                logger.Log(Severity.Error, string.Format("Exception extracting {0}: {1}", assemblyPath, ex));
            }
        }
    }
}
