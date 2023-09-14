#load "../../../packages.csx"

#load "utils.csx"

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
ZipUtil.CompressDirectory(folderPath, zipPath, "123456");

// Descompression
ZipUtil.ExtractZipContent(zipPath, destinationFolderPath, "123456");
