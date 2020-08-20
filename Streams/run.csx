var path = "Streams/data.txt";

var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);

Console.WriteLine("Read:");

// Read byte by byte
for (var i = 0; i < stream.Length; i++)
{
    // Set position
    stream.Seek(i, SeekOrigin.Begin);

    // Get value
    var value = stream.ReadByte();

    // Print value
    Console.Write("{0}\t", (char)value);
}

// Reverse read
Console.WriteLine("\n\nReverse Read:");

// Read byte by byte
for (var i = 1; i <= stream.Length; i++)
{
    // Set position
    stream.Seek(-i, SeekOrigin.End);

    // Get value
    var value = stream.ReadByte();

    // Print value
    Console.Write("{0}\t", (char)value);
}

stream.Close();
