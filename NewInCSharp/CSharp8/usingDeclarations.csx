#load "utils.csx"

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "usingDeclarations.txt");
var lines = new List<string>() { "Hello", "World", "Everybody" };
WriteLinesToFile(lines, path);

public void WriteLinesToFile(IEnumerable<string> lines, string path)
{
    using var file = new StreamWriter(path);
    foreach (string line in lines)
    {
        file.WriteLine(line);
    }
    // file is disposed here
}
