#load "utils.csx"

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Files/log.txt");

Action<string> printLog = (m) => Log(PrintConsole, m);
printLog("Hello World!");
Action<string> saveLog = (m) => Log(SaveFile, m);
saveLog("Hello World!");

public void Log(Action<string> func, string message) => func(message);
public void PrintConsole(string message) => WriteLine(message);
public void SaveFile(string message) => File.WriteAllText(path, message);
