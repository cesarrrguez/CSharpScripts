#load "utils.csx"

using System.Net.Http;

var fileName = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "data.txt");
var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);

Parallel.For(1, 100, new ParallelOptions { MaxDegreeOfParallelism = 4 },
    (i) => Write(fs, i));

fs.Dispose();

public void Write(FileStream fs, int id)
{
    var client = new HttpClient();
    var response = client.GetAsync($"https://jsonplaceholder.typicode.com/todos/{id}").Result;
    var content = response.Content.ReadAsStringAsync().Result + Environment.NewLine;

    lock (fs)
    {
        var bContent = new UTF8Encoding(true).GetBytes(content + Environment.NewLine);
        fs.Write(bContent, 0, bContent.Length);
        fs.Flush();
    }
}
