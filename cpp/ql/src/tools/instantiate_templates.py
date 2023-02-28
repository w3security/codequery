import sys
import os.path
import glob
import re
import json

BEGIN_TEMPLATE = re.compile(r"^/\*template\s*$")
END_TEMPLATE = re.compile(r"^\*/\s*$")

def expand_template_params(args, param_arg_map):
    '''Given a list of template arguments that may reference template parameters
    of the current template, return a new list of template arguments with each
    parameter use replaced with the appropriate fully-qualified argument for
    that parameter.'''
    result = []
    for arg in args:
        if arg in param_arg_map:
            result.append(param_arg_map[arg])
        else:
            result.append(arg)
    
    return result

def find_instantiation(module, args, templates):
    '''Given a template module and a set of template arguments, find the module
    name of the instantiation of that module with those arguments.'''
    template = templates[module]
    for instantiation in template["template_def"]["instantiations"]:
        if instantiation["args"] == args:
            return instantiation["name"]
    return None

def instantiate_template(template, instantiation, root, templates):
    '''Create a single instantiation of a template.'''
    template_def = template["template_def"]
    output_components = instantiation["name"].split(".")
    output_path = root
    for component in output_components:
        output_path = os.path.join(output_path, component)
    output_path = output_path + ".qll"
    with open(output_path, "w") as output:
        output.write(
"""
/*
 * THIS FILE IS AUTOMATICALLY GENERATED FROM '%s'.
 * DO NOT EDIT MANUALLY.
 */

""" % (template["name"].replace(".", "/") + ".qllt")
        )
        param_arg_map = {}
        for param_index in range(len(template_def["params"])):
            param = template_def["params"][param_index]
            arg = instantiation["args"][param_index]
            output.write("private import %s as %s  // Template parameter\n" % (arg, param))
            param_arg_map[param] = arg
        for import_record in template_def["imports"]:
            if "access" in import_record:
                output.write(import_record["access"] + " ")
            imported_module = find_instantiation(import_record["module"],
                expand_template_params(import_record["args"], param_arg_map), templates)
            output.write("import %s  // %s<%s>\n" % 
                (
                    imported_module,
                    import_record["module"],
                    ", ".join(import_record["args"])
                )
            )
            
        output.writelines(template_def["body_lines"])

def generate_instantiations(template, root, templates):
    '''Create a .qll source file for each instantiation of the specified template.'''
    template_def = template["template_def"]
    if "instantiations" in template_def:
        for instantiation in template_def["instantiations"]:
            instantiate_template(template, instantiation, root, templates)

def read_template(template_path, module_name):
    '''Read a .qllt template file from template_path, using module_name as the
    fully qualified name of the module.'''
    with open(template_path) as input:
        in_template = False
        template_text = ""
        template_def = None
        body_lines = []
        for line in iter(input):
            if in_template:
                if END_TEMPLATE.match(line):
                    template_def = json.loads(template_text)
                    in_template = False
                else:
                    template_text += line
            else:
                if BEGIN_TEMPLATE.match(line) and not template_def:
                    in_template = True
                else:
                    body_lines.append(line)

        if template_def:
            template_def["body_lines"] = body_lines

        result = { "name": module_name }
        if template_def:
            result["template_def"] = template_def
        return result

def module_name_from_path_impl(path):
    (head, tail) = os.path.split(path)
    if head == "":
        return tail
    else:
        return module_name_from_path(head) + "." + tail

def module_name_from_path(path):
    '''Compute the fully qualified name of a module from the path of its .qll[t]
    file. The path should be relative to the library root.'''
    (module_root, ext) = os.path.splitext(path)
    return module_name_from_path_impl(module_root)

def main():
    templates = {}

    root = sys.argv[1]
    for template_path in glob.glob(os.path.join(root, "**\\*.qllt"), recursive = True):
        print(template_path)
        module_name = module_name_from_path(os.path.relpath(template_path, root))
        print(module_name)
        template = read_template(template_path, module_name)
        templates[template["name"]] = template

    for name, template in templates.items():
        if "template_def" in template:
            generate_instantiations(template, root, templates)

if __name__ == "__main__":
    main()
