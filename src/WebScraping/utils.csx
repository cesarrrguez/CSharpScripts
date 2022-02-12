using System.Runtime.CompilerServices;
using System.Threading;

public static class FolderUtil
{
    public static string GetCurrentDirectoryName([CallerFilePath] string fileName = null) => Path.GetDirectoryName(fileName);

    public static void CreateFolder(string path)
    {
        if (Directory.Exists(path)) return;
        Directory.CreateDirectory(path);
    }

    public static void CleanupDirectory(string path)
    {
        const int tryCount = 3;

        for (var i = tryCount; i > 0; i--)
        {
            try
            {
                if (!Directory.Exists(path)) continue;

                var directoryInfo = new DirectoryInfo(path);
                var directories = directoryInfo.GetDirectories();

                if (directories.Length == 0) continue;

                foreach (var directory in directories)
                {
                    directory.Delete(true);
                }
                break;
            }
            catch (Exception ex) when (i > 1)
            {
                Debug.WriteLine(ex);
                Thread.Sleep(1000);
            }
        }
    }
}
