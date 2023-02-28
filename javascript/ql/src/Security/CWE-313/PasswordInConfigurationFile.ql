/**
 * @name Password in configuration file
 * @description Storing unencrypted passwords in configuration files is unsafe.
 * @kind problem
 * @problem.severity warning
 * @precision high
 * @id js/password-in-configuration-file
 * @tags security
 *       external/cwe/cwe-256
 *       external/cwe/cwe-260
 *       external/cwe/cwe-313
 */

import javascript

/**
 * Holds if some JSON or YAML file contains a property with name `key`
 * and value `val`, where `valElement` is the entity corresponding to the
 * value.
 *
 * Dependencies in `package.json` files are excluded by this predicate.
 */
predicate config(string key, string val, Locatable valElement) {
  exists (JSONObject obj |
    not exists(PackageJSON p | obj = p.getADependenciesObject(_)) |
    obj.getPropValue(key) = valElement and
    val = valElement.(JSONString).getValue()
  )
  or
  exists (YAMLMapping m, YAMLString keyElement |
    m.maps(keyElement, valElement) and
    key = keyElement.getValue() and
    val = valElement.(YAMLString).getValue()
  )
}

/**
 * Holds if file `f` should be excluded because it looks like it may be
 * a dictionary file, or a test or example.
 */
predicate exclude(File f) {
  f.getRelativePath().regexpMatch(".*(^|/)(lang(uage)?s?|locales?|tests?|examples?)/.*")
}

from string key, string val, Locatable valElement
where config(key, val, valElement) and val != "" and
      (key.toLowerCase() = "password"
       or
       key.toLowerCase() != "readme" and
       val.regexpMatch("(?is).*password\\s*=(?!\\s*;).*")) and
      not exclude(valElement.getFile())
select valElement, "Avoid plaintext passwords in configuration files."
