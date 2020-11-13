#load "utils.csx"

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "data.txt");

var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);

WriteLine("Read:");

// Read byte by byte
for (var i = 0; i < stream.Length; i++)
{
    // Set position
    stream.Seek(i, SeekOrigin.Begin);

    // Get value
    var value = stream.ReadByte();

    // Print value
    Write("{0}\t", (char)value);
}

// Reverse read
WriteLine("\n\nReverse Read:");

// Read byte by byte
for (var i = 1; i <= stream.Length; i++)
{
    // Set position
    stream.Seek(-i, SeekOrigin.End);

    // Get value
    var value = stream.ReadByte();

    // Print value
    Write("{0}\t", (char)value);
}

stream.Close();
