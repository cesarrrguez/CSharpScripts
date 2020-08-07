using System.IO.Compression;
using System.IO;

var folderPath = "Zip/files";
var zipPath = "Zip/files.zip";
var destinationFolderPath = "Zip/files2";

// Clean
File.Delete(zipPath);
if (Directory.Exists(destinationFolderPath))
    Directory.Delete(destinationFolderPath, true);

// Compression
ZipFile.CreateFromDirectory(folderPath, zipPath);

// Descompression
ZipFile.ExtractToDirectory(zipPath, destinationFolderPath);
