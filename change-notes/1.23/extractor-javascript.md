[[ condition: enterprise-only ]]

# Improvements to JavaScript analysis

## Changes to code extraction

* Asynchronous generator methods are now parsed correctly and no longer cause a spurious syntax error.
* Recognition of CommonJS modules has improved. As a result, some files that were previously extracted as
  global scripts are now extracted as modules.
* Top-level `await` is now supported.
* A bug was fixed in how the TypeScript extractor handles default-exported anonymous classes.
* A bug was fixed in how the TypeScript extractor handles computed instance field names.
