#load "../../packages.csx"

#load "utils.csx"

using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "hello.py");

ScriptRuntime py = Python.CreateRuntime();
dynamic program = py.UseFile(path);
program.Hi("César", "Rodríguez");
