using System.Runtime.CompilerServices;

public static class FolderUtil
{
    public static string GetCurrentDirectoryName([CallerFilePath] string fileName = null) => Path.GetDirectoryName(fileName);
}

// Extensions
// ------------------------------------------------------------

public static string ToYesNoString(this bool value)
{
    return value ? "Yes" : "No";
}
