#load "utils.csx"

var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "data.txt");

var stream = new StreamReader(path);

WriteLine("Read:");

var line = "";
// Read line by line
while ((line = stream.ReadLine()) != null)
{
    WriteLine(line);
}

stream.Close();
