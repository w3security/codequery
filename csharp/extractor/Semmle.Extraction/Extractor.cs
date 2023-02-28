using System;
using System.Collections.Generic;
using Semmle.Util;
using Semmle.Util.Logging;

namespace Semmle.Extraction
{
    /// <summary>
    /// Provides common extraction functions for use during extraction.
    /// </summary>
    ///
    /// <remarks>
    /// This is held in the <see cref="Context"/> passed to each entity.
    /// </remarks>
    public interface IExtractor
    {
        /// <summary>
        /// Logs a message (to csharp.log).
        /// Increases the error count if msg.severity is Error.
        /// </summary>
        /// <param name="msg">The message to log.</param>
        void Message(Message msg);

        /// <summary>
        /// Cache assembly names.
        /// </summary>
        /// <param name="assembly">The assembly name.</param>
        /// <param name="file">The file defining the assembly.</param>
        void SetAssemblyFile(string assembly, string file);

        /// <summary>
        /// Maps assembly names to file names.
        /// </summary>
        /// <param name="assembly">The assembly name</param>
        /// <returns>The file defining the assmebly.</returns>
        string GetAssemblyFile(string assembly);

        /// <summary>
        /// How many errors encountered during extraction?
        /// </summary>
        int Errors { get; }

        /// <summary>
        /// The extraction is standalone - meaning there will be a lot of errors.
        /// </summary>
        bool Standalone { get; }

        /// <summary>
        /// Record a new error type.
        /// </summary>
        /// <param name="fqn">The display name of the type, qualified where possible.</param>
        void MissingType(string fqn);

        /// <summary>
        /// Record an unresolved `using namespace` directive.
        /// </summary>
        /// <param name="fqn">The full name of the namespace.</param>
        void MissingNamespace(string fqn);

        /// <summary>
        /// The list of missing types.
        /// </summary>
        IEnumerable<string> MissingTypes { get; }

        /// <summary>
        /// The list of missing namespaces.
        /// </summary>
        IEnumerable<string> MissingNamespaces { get; }

        /// <summary>
        /// The full path of the generated DLL/EXE.
        /// null if not specified.
        /// </summary>
        string OutputPath { get; }

        /// <summary>
        /// The object used for logging.
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// The extractor SHA, obtained from the git log.
        /// </summary>
        string Version { get; }
    }

    /// <summary>
    /// Implementation of the main extractor state.
    /// </summary>
    public class Extractor : IExtractor
    {
        /// <summary>
        /// The default number of threads to use for extraction.
        /// </summary>
        public static readonly int DefaultNumberOfThreads = Environment.ProcessorCount;

        public bool Standalone
        {
            get; private set;
        }

        /// <summary>
        /// Creates a new extractor instance for one compilation unit.
        /// </summary>
        /// <param name="standalone">If the extraction is standalone.</param>
        /// <param name="outputPath">The name of the output DLL/EXE, or null if not specified (standalone extraction).</param>
        public Extractor(bool standalone, string outputPath, ILogger logger)
        {
            Standalone = standalone;
            OutputPath = outputPath;
            Logger = logger;
        }

        // Limit the number of error messages in the log file
        // to handle pathological cases.
        const int maxErrors = 1000;

        readonly object mutex = new object();

        public void Message(Message msg)
        {
            lock (mutex)
            {

                if (msg.severity == Severity.Error)
                {
                    ++Errors;
                    if (Errors == maxErrors)
                    {
                        Logger.Log(Severity.Info, "  Stopping logging after {0} errors", Errors);
                    }
                }

                if (Errors >= maxErrors)
                {
                    return;
                }

                Logger.Log(msg.severity, "  {0}", msg.message);

                if (msg.node != null)
                {
                    Logger.Log(msg.severity, "    Syntax element '{0}' at {1}", msg.node, msg.node.GetLocation().GetLineSpan());
                }

                if (msg.symbol != null)
                {
                    Logger.Log(msg.severity, "    Symbol '{0}'", msg.symbol);
                    foreach (var l in msg.symbol.Locations)
                        Logger.Log(msg.severity, "    Location: {0}", l.IsInSource ? l.GetLineSpan().ToString() : l.MetadataModule.ToString());
                }

                if (msg.exception != null)
                {
                    Logger.Log(msg.severity, "    Exception: {0}", msg.exception);
                }
            }
        }

        // Roslyn framework has no apparent mechanism to associate assemblies with their files.
        // So this lookup table needs to be populated.
        readonly Dictionary<string, string> referenceFilenames = new Dictionary<string, string>();

        public void SetAssemblyFile(string assembly, string file)
        {
            referenceFilenames[assembly] = file;
        }

        public string GetAssemblyFile(string assembly)
        {
            return referenceFilenames[assembly];
        }

        public int Errors
        {
            get; private set;
        }

        readonly ISet<string> missingTypes = new SortedSet<string>();
        readonly ISet<string> missingNamespaces = new SortedSet<string>();

        public void MissingType(string fqn)
        {
            lock (mutex)
                missingTypes.Add(fqn);
        }

        public void MissingNamespace(string fqdn)
        {
            lock (mutex)
                missingNamespaces.Add(fqdn);
        }

        public IEnumerable<string> MissingTypes => missingTypes;

        public IEnumerable<string> MissingNamespaces => missingNamespaces;

        public string OutputPath
        {
            get;
            private set;
        }

        public ILogger Logger { get; private set; }

        public string Version => $"{ThisAssembly.Git.BaseTag} ({ThisAssembly.Git.Sha})";
    }
}
