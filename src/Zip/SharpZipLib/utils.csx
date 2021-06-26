using System.Runtime.CompilerServices;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

public static class FolderUtil
{
    public static string GetCurrentDirectoryName([CallerFilePath] string fileName = null) => Path.GetDirectoryName(fileName);
}

public static class ZipUtil
{
    public static void CompressDirectory(string directoryPath, string outputFilePath, string password = null, int compressionLevel = 9)
    {
        try
        {
            string[] filenames = Directory.GetFiles(directoryPath);

            using ZipOutputStream outputStream = new ZipOutputStream(File.Create(outputFilePath));

            if (!string.IsNullOrEmpty(password))
            {
                outputStream.Password = password;
            }

            // Compression level: 0 to 9 (best compression)
            outputStream.SetLevel(compressionLevel);

            byte[] buffer = new byte[4096];

            foreach (string file in filenames)
            {
                ZipEntry entry = new ZipEntry(Path.GetFileName(file))
                {
                    DateTime = DateTime.Now
                };

                outputStream.PutNextEntry(entry);

                using FileStream fs = File.OpenRead(file);

                int sourceBytes;

                do
                {
                    sourceBytes = fs.Read(buffer, 0, buffer.Length);
                    outputStream.Write(buffer, 0, sourceBytes);
                } while (sourceBytes > 0);
            }

            outputStream.Finish();
            outputStream.Close();

            WriteLine("Files successfully compressed");
        }
        catch (Exception ex)
        {
            WriteLine("Exception during processing {0}", ex);
        }
    }

    public static void ExtractZipContent(string fileZipPath, string outputFolder, string password)
    {
        ZipFile file = null;
        try
        {
            FileStream fs = File.OpenRead(fileZipPath);
            file = new ZipFile(fs);

            if (!string.IsNullOrEmpty(password))
            {
                file.Password = password;
            }

            foreach (ZipEntry zipEntry in file)
            {
                if (!zipEntry.IsFile)
                {
                    // Ignore directories
                    continue;
                }

                string entryFileName = zipEntry.Name;

                // 4K is optimum
                byte[] buffer = new byte[4096];
                Stream zipStream = file.GetInputStream(zipEntry);

                string fullZipToPath = Path.Combine(outputFolder, entryFileName);
                string directoryName = Path.GetDirectoryName(fullZipToPath);

                if (directoryName.Length > 0)
                {
                    Directory.CreateDirectory(directoryName);
                }

                using FileStream streamWriter = File.Create(fullZipToPath);
                StreamUtils.Copy(zipStream, streamWriter, buffer);
            }
        }
        finally
        {
            if (file != null)
            {
                file.IsStreamOwner = true;
                file.Close();
            }
        }
    }
}
