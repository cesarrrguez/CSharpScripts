using System.Runtime.CompilerServices;

public static class FolderUtil
{
    public static string GetCurrentDirectoryName([CallerFilePath] string fileName = null) => Path.GetDirectoryName(fileName);
}

public static class EnvironmentUtil
{
    public const string URL = "https://jsonplaceholder.typicode.com";
}

public enum Action
{
    Posts,
    Photos
}
