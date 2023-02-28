package com.semmle.js.extractor;

import java.io.File;
import java.io.IOException;
import java.io.Reader;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.FileVisitResult;
import java.nio.file.FileVisitor;
import java.nio.file.Files;
import java.nio.file.InvalidPathException;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.SimpleFileVisitor;
import java.nio.file.attribute.BasicFileAttributes;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;
import java.util.stream.Stream;

import com.semmle.js.extractor.ExtractorConfig.SourceType;
import com.semmle.js.extractor.FileExtractor.FileType;
import com.semmle.js.extractor.trapcache.DefaultTrapCache;
import com.semmle.js.extractor.trapcache.DummyTrapCache;
import com.semmle.js.extractor.trapcache.ITrapCache;
import com.semmle.js.parser.ParsedProject;
import com.semmle.js.parser.TypeScriptParser;
import com.semmle.ts.extractor.TypeExtractor;
import com.semmle.ts.extractor.TypeTable;
import com.semmle.util.data.StringUtil;
import com.semmle.util.exception.Exceptions;
import com.semmle.util.exception.ResourceError;
import com.semmle.util.exception.UserError;
import com.semmle.util.extraction.ExtractorOutputConfig;
import com.semmle.util.files.FileUtil;
import com.semmle.util.io.csv.CSVReader;
import com.semmle.util.language.LegacyLanguage;
import com.semmle.util.process.Env;
import com.semmle.util.projectstructure.ProjectLayout;
import com.semmle.util.trap.TrapWriter;

/**
 * An alternative entry point to the JavaScript extractor.
 *
 * <p>
 * It assumes the following environment variables to be set:
 * </p>
 *
 * <ul>
 * <li><code>LGTM_SRC</code>: the source root;</li>
 * <li><code>SEMMLE_DIST</code>: the distribution root.</li>
 * </ul>
 *
 * <p>
 * It extracts the following:
 * </p>
 *
 * <ol>
 * <li>all <code>*.js</code> files under <code>$SEMMLE_DIST/tools/data/externs</code>
 *     (cf. {@link AutoBuild#extractExterns()};</li>
 * <li>all source code files (cf. {@link AutoBuild#extractSource()}.</li>
 * </ol>
 *
 * <p>
 * In the second step, the set of files to extract is determined in two phases: the walking
 * phase, which computes a set of candidate files, and the filtering phase. A file is
 * extracted if it is a candidate, its type is supported
 * (cf. {@link FileExtractor#supports(File)}), and it is not filtered out in the filtering phase.
 * </p>
 *
 * <p>
 * The walking phase is parameterised by a set of <i>include paths</i> and a set of <i>exclude
 * paths</i>. By default, the single include path is <code>LGTM_SRC</code>. If the environment
 * variable <code>LGTM_INDEX_INCLUDE</code> is set, it is interpreted as a newline-separated list
 * of include paths, which are slash-separated paths relative to <code>LGTM_SRC</code>. This
 * list <i>replaces</i> (rather than extends) the default include path.
 * </p>
 *
 * <p>
 * Similarly, the set of exclude paths is determined by the environment variables
 * <code>LGTM_INDEX_EXCLUDE</code> and <code>LGTM_REPOSITORY_FOLDERS_CSV</code>. The former
 * is interpreted like <code>LGTM_INDEX_EXCLUDE</code>, that is, a newline-separated list
 * of exclude paths relative to <code>LGTM_SRC</code>. The latter is interpreted as
 * the path of a CSV file, where each line in the file consists of a classification tag
 * and an absolute path; any path classified as "external" or "metadata" becomes an
 * exclude path. Note that there are no implicit exclude paths.
 * </p>
 *
 * <p>
 * The walking phase starts at each include path in turn and recursively traverses folders and
 * files. Symlinks and hidden folders are skipped, but not hidden files. If it encounters a
 * sub-folder whose path is excluded, traversal stops. If it encounters a file, that file
 * becomes a candidate, unless its path is excluded. If the path of a file is both an include
 * path and an exclude path, the inclusion takes precedence, and the file becomes a candidate
 * after all.
 * </p>
 *
 * <p>
 * If an include or exclude path cannot be resolved, a warning is printed and the path is ignored.
 * </p>
 *
 * <p>
 * Note that the overall effect of this procedure is that the precedence of include and
 * exclude paths is derived from their specificity: a more specific include/exclude takes
 * precedence over a less specific include/exclude. In case of a tie, the include takes
 * precedence.
 * </p>
 *
 * <p>
 * The filtering phase is parameterised by a list of include/exclude patterns in the style of
 * {@link ProjectLayout} specifications. There are some built-in include/exclude patterns discussed
 * below. Additionally, the environment variable <code>LGTM_INDEX_FILTERS</code> is interpreted
 * as a newline-separated list of patterns to append to that list (hence taking precedence over
 * the built-in patterns). Unlike for {@link ProjectLayout}, patterns in
 * <code>LGTM_INDEX_FILTERS</code> use the syntax <code>include: pattern</code> for inclusions
 * and <code>exclude: pattern</code> for exclusions.
 * </p>
 *
 * <p>
 * The default inclusion patterns cause the following files to be included:
 * </p>
 * <ul>
 * <li>All JavaScript files, that is, files with one of the extensions supported by
 *     {@link FileType#JS} (currently ".js", ".jsx", ".mjs", ".es6", ".es").</li>
 * <li>All HTML files, that is, files with with one of the extensions supported by
 *     {@link FileType#HTML} (currently ".htm", ".html", ".xhtm", ".xhtml", ".vue").</li>
 * <li>Files with base name "package.json".</li>
 * <li>JavaScript, JSON or YAML files whose base name starts with ".eslintrc".</li>
 * <li>All extension-less files.</li>
 * </ul>
 *
 * <p>
 * Additionally, if the environment variable <code>LGTM_INDEX_TYPESCRIPT</code> is set to
 * "basic" (default) or "full", files with one of the extensions supported by {@link FileType#TYPESCRIPT} (currently
 * ".ts" and ".tsx") are also included. In case of "full", type information from the TypeScript
 * compiler is extracted as well.
 * </p>
 *
 * <p>
 * The default exclusion patterns cause the following files to be excluded:
 * </p>
 * <ul>
 * <li>All JavaScript files whose name ends with <code>-min.js</code> or <code>.min.js</code>.
 *     Such files typically contain minified code. Since LGTM by default does not show results
 *     in minified files, it is not usually worth extracting them in the first place.</li>
 * </ul>
 *
 * <p>
 * JavaScript files are normally extracted with {@link SourceType#AUTO}, but an explicit
 * source type can be specified in the environment variable <code>LGTM_INDEX_SOURCE_TYPE</code>.
 * </p>
 *
 * <p>
 * Note that all these customisations only apply to <code>LGTM_SRC</code>. Extraction of
 * externs is not customisable.
 * </p>
 *
 * <p>
 * Finally, the environment variables <code>LGTM_TRAP_CACHE</code> and
 * <code>LGTM_TRAP_CACHE_BOUND</code> can optionally be used to specify the location and size
 * of a trap cache to be used during extraction.
 * </p>
 */
public class AutoBuild {
	private final ExtractorOutputConfig outputConfig;
	private final ITrapCache trapCache;
	private Set<Path> includes = new LinkedHashSet<>();
	private Set<Path> excludes = new LinkedHashSet<>();
	private ProjectLayout filters;
	private final Path LGTM_SRC, SEMMLE_DIST;
	private final TypeScriptMode typeScriptMode;
	private final String defaultEncoding;
	private ExtractorState extractorState;
	private long timedLogMessageStart = 0;

	public AutoBuild() {
		this.LGTM_SRC = toRealPath(getPathFromEnvVar("LGTM_SRC"));
		this.SEMMLE_DIST = getPathFromEnvVar(Env.Var.SEMMLE_DIST.toString());
		this.outputConfig = new ExtractorOutputConfig(LegacyLanguage.JAVASCRIPT);
		this.trapCache = mkTrapCache();
		this.typeScriptMode = getEnumFromEnvVar("LGTM_INDEX_TYPESCRIPT", TypeScriptMode.class, TypeScriptMode.BASIC);
		this.defaultEncoding = getEnvVar("LGTM_INDEX_DEFAULT_ENCODING");
		this.extractorState = new ExtractorState();
		setupMatchers();
	}

	private String getEnvVar(String envVarName) {
		return getEnvVar(envVarName, null);
	}

	private String getEnvVar(String envVarName, String deflt) {
		String value = Env.systemEnv().getNonEmpty(envVarName);
		if (value == null)
			return deflt;
		return value;
	}

	private Path getPathFromEnvVar(String envVarName) {
		String lgtmSrc = getEnvVar(envVarName);
		if (lgtmSrc == null)
			throw new UserError(envVarName + " must be set.");
		Path path = Paths.get(lgtmSrc);
		return path;
	}

	private <T extends Enum<T>> T getEnumFromEnvVar(String envVarName, Class<T> enumClass, T defaultValue) {
		String envValue = getEnvVar(envVarName);
		if (envValue == null)
			return defaultValue;
		try {
			return Enum.valueOf(enumClass, StringUtil.uc(envValue));
		} catch (IllegalArgumentException ex) {
			Exceptions.ignore(ex, "We rewrite this to a meaningful user error.");
			Stream<String> enumNames = Arrays.asList(enumClass.getEnumConstants()).stream().map(c -> StringUtil.lc(c.toString()));
			throw new UserError(envVarName + " must be set to one of: " + StringUtil.glue(", ", enumNames.toArray()));
		}
	}

	/**
	 * Convert {@code p} to a real path (as per {@link Path#toRealPath(java.nio.file.LinkOption...)}),
	 * throwing a {@link ResourceError} if this fails.
	 */
	private Path toRealPath(Path p) {
		try {
			return p.toRealPath();
		} catch (IOException e) {
			throw new ResourceError("Could not compute real path for " + p + ".", e);
		}
	}

	/**
	 * Set up TRAP cache based on environment variables <code>LGTM_TRAP_CACHE</code> and
	 * <code>LGTM_TRAP_CACHE_BOUND</code>.
	 */
	private ITrapCache mkTrapCache() {
		ITrapCache trapCache;
		String trapCachePath = getEnvVar("LGTM_TRAP_CACHE");
		if (trapCachePath != null) {
			Long sizeBound = null;
			String trapCacheBound = getEnvVar("LGTM_TRAP_CACHE_BOUND");
			if (trapCacheBound != null) {
				sizeBound = DefaultTrapCache.asFileSize(trapCacheBound);
				if (sizeBound == null)
					throw new UserError("Invalid TRAP cache size bound: " + trapCacheBound);
			}
			trapCache = new DefaultTrapCache(trapCachePath, sizeBound, Main.EXTRACTOR_VERSION);
		} else {
			trapCache = new DummyTrapCache();
		}
		return trapCache;
	}

	/**
	 * Set up include and exclude matchers based on environment variables.
	 */
	private void setupMatchers() {
		setupIncludesAndExcludes();
		setupFilters();
	}

	/**
	 * Set up include matchers based on <code>LGTM_INDEX_INCLUDE</code> and
	 * <code>LGTM_INDEX_TYPESCRIPT</code>.
	 */
	private void setupIncludesAndExcludes() {
		// process `$LGTM_INDEX_INCLUDE` and `$LGTM_INDEX_EXCLUDE`
		boolean seenInclude = false;
		for (String pattern : Main.NEWLINE.split(getEnvVar("LGTM_INDEX_INCLUDE", "")))
			seenInclude |= addPathPattern(includes, LGTM_SRC, pattern);
		if (!seenInclude)
			includes.add(LGTM_SRC);
		for (String pattern : Main.NEWLINE.split(getEnvVar("LGTM_INDEX_EXCLUDE", "")))
			addPathPattern(excludes, LGTM_SRC, pattern);

		// process `$LGTM_REPOSITORY_FOLDERS_CSV`
		String lgtmRepositoryFoldersCsv = getEnvVar("LGTM_REPOSITORY_FOLDERS_CSV");
		if (lgtmRepositoryFoldersCsv != null) {
			Path path = Paths.get(lgtmRepositoryFoldersCsv);
			try (Reader reader = Files.newBufferedReader(path, StandardCharsets.UTF_8);
					CSVReader csv = new CSVReader(reader)) {
				// skip titles
				csv.readNext();
				String[] fields;
				while ((fields = csv.readNext()) != null) {
					if (fields.length != 2)
						continue;
					if ("external".equals(fields[0]) || "metadata".equals(fields[0])) {
						String folder = fields[1];
						try {
							Path folderPath = folder.startsWith("file://") ? Paths.get(new URI(folder)) : Paths.get(folder);
							excludes.add(toRealPath(folderPath));
						} catch (InvalidPathException | URISyntaxException | ResourceError e) {
							Exceptions.ignore(e, "Ignore path and print warning message instead");
							warn("Ignoring '" + fields[0] + "' classification for " +
									folder + ", which is not a valid path.");
						}
					}
				}
			} catch (IOException e) {
				throw new ResourceError("Unable to process LGTM repository folder CSV.", e);
			}
		}
	}

	private void setupFilters() {
		List<String> patterns = new ArrayList<String>();
		patterns.add("/");

		// exclude all files with extensions
		patterns.add("-**/*.*");

		// but include HTML, JavaScript and (optionally) TypeScript
		Set<FileType> defaultExtract = new LinkedHashSet<FileType>();
		defaultExtract.add(FileType.HTML);
		defaultExtract.add(FileType.JS);
		if (typeScriptMode != TypeScriptMode.NONE)
			defaultExtract.add(FileType.TYPESCRIPT);
		for (FileType filetype : defaultExtract)
			for (String extension : filetype.getExtensions())
				patterns.add("**/*" + extension);

		// include .eslintrc files and package.json files
		patterns.add("**/.eslintrc*");
		patterns.add("**/package.json");

		// exclude files whose name strongly suggests they are minified
		patterns.add("-**/*.min.js");
		patterns.add("-**/*-min.js");

		String base = LGTM_SRC.toString().replace('\\', '/');
		// process `$LGTM_INDEX_FILTERS`
		for (String pattern : Main.NEWLINE.split(getEnvVar("LGTM_INDEX_FILTERS", ""))) {
			pattern = pattern.trim();
			if (pattern.isEmpty())
				continue;
			String[] fields = pattern.split(":");
			if (fields.length != 2)
				continue;
			pattern = fields[1].trim();
			pattern = base + "/" + pattern;
			if ("exclude".equals(fields[0].trim()))
				pattern = "-" + pattern;
			patterns.add(pattern);
		}

		filters = new ProjectLayout(patterns.toArray(new String[0]));
	}

	/**
	 * Add {@code pattern} to {@code patterns}, trimming off whitespace and prepending
	 * {@code base} to it. If {@code pattern} ends with a trailing slash, that slash
	 * is stripped off.
	 *
	 * @return true if {@code pattern} is non-empty
	 */
	private boolean addPathPattern(Set<Path> patterns, Path base, String pattern) {
		pattern = pattern.trim();
		if (pattern.isEmpty())
			return false;
		Path path = base.resolve(pattern);
		try {
			Path realPath = toRealPath(path);
			patterns.add(realPath);
		} catch (ResourceError e) {
			Exceptions.ignore(e, "Ignore exception and print warning instead.");
			warn("Skipping path " + path + ", which does not exist.");
		}
		return true;
	}

	/**
	 * Perform extraction.
	 */
	public void run() throws IOException {
		extractExterns();
		extractSource();
	}

	/**
	 * Extract all "*.js" files under <code>$SEMMLE_DIST/tools/data/externs</code> as
	 * externs.
	 */
	private void extractExterns() throws IOException {
		ExtractorConfig config = new ExtractorConfig(false).withExterns(true);

		// use explicitly specified trap cache, or otherwise $SEMMLE_DIST/.cache/trap-cache/javascript,
		// which we pre-populate when building the distribution
		ITrapCache trapCache = this.trapCache;
		if (trapCache instanceof DummyTrapCache) {
			Path trapCachePath = SEMMLE_DIST.resolve(".cache").resolve("trap-cache").resolve("javascript");
			if (Files.isDirectory(trapCachePath)) {
				trapCache = new DefaultTrapCache(trapCachePath.toString(), null, Main.EXTRACTOR_VERSION) {
					boolean warnedAboutCacheMiss = false;

					@Override
					public File lookup(String source, ExtractorConfig config, FileType type) {
						File f = super.lookup(source, config, type);
						// only return `f` if it exists; this has the effect of making the cache read-only
						if (f.exists())
							return f;
						// warn on first failed lookup
						if (!warnedAboutCacheMiss) {
							warn("Trap cache lookup for externs failed.");
							warnedAboutCacheMiss = true;
						}
						return null;
					}
				};
			} else {
				warn("No externs trap cache found");
			}
		}

		FileExtractor extractor = new FileExtractor(config, outputConfig, trapCache, extractorState);
		FileVisitor<? super Path> visitor = new SimpleFileVisitor<Path>() {
			@Override
			public FileVisitResult visitFile(Path file, BasicFileAttributes attrs) throws IOException {
				if (".js".equals(FileUtil.extension(file.toString())))
					extract(extractor, file);
				return super.visitFile(file, attrs);
			}
		};
		Path externs = SEMMLE_DIST.resolve("tools").resolve("data").resolve("externs");
		Files.walkFileTree(externs, visitor);
	}

	/**
	 * Extract all supported candidate files that pass the filters.
	 */
	private void extractSource() throws IOException {
		ExtractorConfig config = new ExtractorConfig(true);
		config = config.withSourceType(getSourceType());
		config = config.withTypeScriptMode(typeScriptMode);
		if (defaultEncoding != null)
			config = config.withDefaultEncoding(defaultEncoding);
		FileExtractor extractor = new FileExtractor(config, outputConfig, trapCache, extractorState);
		Path[] currentRoot = new Path[1];
		final Set<Path> filesToExtract = new LinkedHashSet<>();
		final List<Path> tsconfigFiles = new ArrayList<>();
		FileVisitor<? super Path> visitor = new SimpleFileVisitor<Path>() {
			private boolean isFileIncluded(Path file) {
				// normalise path for matching
				String path = file.toString().replace('\\', '/');
				if (path.charAt(0) != '/')
					path = "/" + path;
				return filters.includeFile(path);
			}

			@Override
			public FileVisitResult visitFile(Path file, BasicFileAttributes attrs) throws IOException {
				if (attrs.isSymbolicLink())
					return FileVisitResult.SKIP_SUBTREE;

				if (!file.equals(currentRoot[0]) && excludes.contains(file))
					return FileVisitResult.SKIP_SUBTREE;

				// extract files that are supported and pass the include/exclude patterns
				if (extractor.supports(file.toFile()) && isFileIncluded(file)) {
					filesToExtract.add(normalizePath(file));
				}

				// extract TypeScript projects from 'tsconfig.json'
				if (typeScriptMode == TypeScriptMode.FULL && file.getFileName().endsWith("tsconfig.json") && !excludes.contains(file)) {
					tsconfigFiles.add(file);
				}

				return super.visitFile(file, attrs);
			}

			@Override
			public FileVisitResult preVisitDirectory(Path dir, BasicFileAttributes attrs) throws IOException {
				if (!dir.equals(currentRoot[0]) && (excludes.contains(dir) || dir.toFile().isHidden()))
					return FileVisitResult.SKIP_SUBTREE;
				return super.preVisitDirectory(dir, attrs);
			}
		};
		for (Path root : includes) {
			currentRoot[0] = root;
			Files.walkFileTree(currentRoot[0], visitor);
		}

		// If there are any .ts files, verify that TypeScript is installed.
		TypeScriptParser tsParser = extractorState.getTypeScriptParser();
		boolean hasTypeScriptFiles = false;
		for (Path file : filesToExtract) {
			// Check if there are any files with the TypeScript extension.
			// Do not use FileType.forFile as it involves I/O for file header checks,
			// and files with a bad header have already been excluded.
			if (FileType.forFileExtension(file.toFile()) == FileType.TYPESCRIPT) {
				hasTypeScriptFiles = true;
				break;
			}
		}
		if (hasTypeScriptFiles || !tsconfigFiles.isEmpty()) {
			verifyTypeScriptInstallation();
		}

		// Extract TypeScript projects
		Set<Path> extractedFiles = new LinkedHashSet<>();
		for (Path projectPath : tsconfigFiles) {
			File projectFile = projectPath.toFile();
			logBeginProcess("Opening project " + projectFile);
			ParsedProject project = tsParser.openProject(projectFile);
			logEndProcess();
			// Extract all files belonging to this project which are also matched
			// by our include/exclude filters.
			List<File> typeScriptFiles = new ArrayList<File>();
			for (File sourceFile : project.getSourceFiles()) {
				Path sourcePath = sourceFile.toPath();
				if (!filesToExtract.contains(normalizePath(sourcePath)))
					continue;
				if (!extractedFiles.contains(sourcePath)) {
					typeScriptFiles.add(sourcePath.toFile());
				}
			}
			extractTypeScriptFiles(typeScriptFiles, extractedFiles, extractor);
			tsParser.closeProject(projectFile);
		}

		if (!tsconfigFiles.isEmpty()) {
			// Extract all the types discovered when extracting the ASTs.
			TypeTable typeTable = tsParser.getTypeTable();
			extractTypeTable(tsconfigFiles.iterator().next(), typeTable);
		}

		// Extract remaining TypeScript files.
		List<File> remainingTypeScriptFiles = new ArrayList<File>();
		for (Path f : filesToExtract) {
			if (!extractedFiles.contains(f) && FileType.forFileExtension(f.toFile()) == FileType.TYPESCRIPT) {
				remainingTypeScriptFiles.add(f.toFile());
			}
		}
		if (!remainingTypeScriptFiles.isEmpty()) {
			extractTypeScriptFiles(remainingTypeScriptFiles, extractedFiles, extractor);
		}

		// The TypeScript compiler instance is no longer needed.
		tsParser.killProcess();

		// Extract non-TypeScript files
		for (Path f : filesToExtract) {
			if (extractedFiles.add(f)) {
				extract(extractor, f);
			}
		}
	}

	/**
	 * Verifies that Node.js and the TypeScript compiler are installed and can be
	 * found.
	 */
	public void verifyTypeScriptInstallation() {
		extractorState.getTypeScriptParser().verifyInstallation(true);
	}

	public void extractTypeScriptFiles(List<File> files, Set<Path> extractedFiles, FileExtractor extractor) throws IOException {
		extractorState.getTypeScriptParser().prepareFiles(files);
		for (File f : files) {
			Path path = f.toPath();
			extractedFiles.add(path);
			extract(extractor, f.toPath());
		}
	}

	private Path normalizePath(Path path) {
		return path.toAbsolutePath().normalize();
	}

	private void extractTypeTable(Path fileHandle, TypeTable table) {
		TrapWriter trapWriter = outputConfig.getTrapWriterFactory().mkTrapWriter(fileHandle.toFile());
		try {
			new TypeExtractor(trapWriter, table).extract();
		} finally {
			FileUtil.close(trapWriter);
		}
	}

	/**
	 * Get the source type specified in <code>LGTM_INDEX_SOURCE_TYPE</code>,
	 * or the default of {@link SourceType#AUTO}.
	 */
	private SourceType getSourceType() {
		String sourceTypeName = getEnvVar("LGTM_INDEX_SOURCE_TYPE");
		if (sourceTypeName != null) {
			try {
				return SourceType.valueOf(StringUtil.uc(sourceTypeName));
			} catch (IllegalArgumentException e) {
				Exceptions.ignore(e, "We construct a better error message.");
				throw new UserError(sourceTypeName + " is not a valid source type.");
			}
		}
		return SourceType.AUTO;
	}

	/**
	 * Extract a single file.
	 */
	protected void extract(FileExtractor extractor, Path file) throws IOException {
		File f = file.toFile();
		if (!f.exists()) {
			warn("Skipping " + file + ", which does not exist.");
			return;
		}

		logBeginProcess("Extracting " + file);
		extractor.extract(f);
		logEndProcess();
	}

	private void warn(String msg) {
		System.err.println(msg);
		System.err.flush();
	}

	private void logBeginProcess(String message) {
		System.out.print(message + "...");
		System.out.flush();
		this.timedLogMessageStart = System.nanoTime();
	}

	private void logEndProcess() {
		long end = System.nanoTime();
		int milliseconds = (int) ((end - this.timedLogMessageStart) / 1000000);
		System.out.println(" done (" + milliseconds + " ms)");
	}

	public static void main(String[] args) {
		try {
			new AutoBuild().run();
		} catch (IOException | UserError e) {
			System.err.println(e.toString());
			System.exit(1);
		}
	}
}
