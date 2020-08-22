//string path = "\\MyServer\TestFolder\NewFolder"; // "Unrecognized escape sequence" error
string path = @"\\MyServer\TestFolder\NewFolder";
Console.WriteLine(path);
