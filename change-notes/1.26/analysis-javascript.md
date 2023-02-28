# Improvements to JavaScript analysis

## General improvements

* Support for the following frameworks and libraries has been improved:
  - [fast-json-stable-stringify](https://www.npmjs.com/package/fast-json-stable-stringify)
  - [fast-safe-stringify](https://www.npmjs.com/package/fast-safe-stringify)
  - [javascript-stringify](https://www.npmjs.com/package/javascript-stringify)
  - [js-stringify](https://www.npmjs.com/package/js-stringify)
  - [json-stable-stringify](https://www.npmjs.com/package/json-stable-stringify)
  - [json-stringify-safe](https://www.npmjs.com/package/json-stringify-safe)
  - [json3](https://www.npmjs.com/package/json3)
  - [object-inspect](https://www.npmjs.com/package/object-inspect)
  - [pretty-format](https://www.npmjs.com/package/pretty-format)
  - [stringify-object](https://www.npmjs.com/package/stringify-object)

* Analyzing files with the ".cjs" extension is now supported.

## New queries

| **Query**                                                                       | **Tags**                                                          | **Purpose**                                                                                                                                                                            |
|---------------------------------------------------------------------------------|-------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|


## Changes to existing queries

| **Query**                      | **Expected impact**          | **Change**                                                                |
|--------------------------------|------------------------------|---------------------------------------------------------------------------|
| Potentially unsafe external link (`js/unsafe-external-link`) | Fewer results | This query no longer flags URLs constructed using a template system where only the hash or query part of the URL is dynamic. |
| Incomplete URL substring sanitization (`js/incomplete-url-substring-sanitization`) | More results | This query now recognizes additional URLs when the substring check is an inclusion check. |
| Ambiguous HTML id attribute (`js/duplicate-html-id`) | Results no longer shown | Precision tag reduced to "low". The query is no longer run by default. |
| Unused loop iteration variable (`js/unused-loop-variable`) | Fewer results | This query no longer flags variables in a destructuring array assignment that are not the last variable in the destructed array. |
| Unsafe shell command constructed from library input (`js/shell-command-constructed-from-input`) | More results | This query now recognizes more commands where colon, dash, and underscore are used. |
| Unsafe jQuery plugin (`js/unsafe-jquery-plugin`) | More results | This query now detects more unsafe uses of nested option properties. |


## Changes to libraries
* The predicate `TypeAnnotation.hasQualifiedName` now works in more cases when the imported library was not present during extraction.
