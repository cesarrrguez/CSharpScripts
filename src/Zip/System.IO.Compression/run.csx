#load "utils.csx"

using System.IO.Compression;

var folderPath = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "files");
var zipPath = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "files.zip");
var destinationFolderPath = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "files2");

// Clean
File.Delete(zipPath);
if (Directory.Exists(destinationFolderPath))
{
    Directory.Delete(destinationFolderPath, true);
}

// Compression
ZipFile.CreateFromDirectory(folderPath, zipPath);

// Descompression
ZipFile.ExtractToDirectory(zipPath, destinationFolderPath);
