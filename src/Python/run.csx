#load "utils.csx"

#r "nuget: DynamicLanguageRuntime, 1.3.0"
#r "nuget: IronPython, 2.7.11"

using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "hello.py");

ScriptRuntime py = Python.CreateRuntime();
dynamic program = py.UseFile(path);
program.Hi("César", "Rodríguez");
