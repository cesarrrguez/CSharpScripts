#load "utils.csx"

using System.Net.Http;

var fileName = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "data.txt");
var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);

var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 4 };
await Parallel.ForEachAsync(Enumerable.Range(1, 1000), parallelOptions, async (id, _) => await WriteAsync(fs, id));

fs.Dispose();

public async Task WriteAsync(FileStream fs, int id)
{
    var client = new HttpClient();
    var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/todos/{id}");
    var content = await response.Content.ReadAsStringAsync() + Environment.NewLine;

    lock (fs)
    {
        var bContent = new UTF8Encoding(true).GetBytes(content + Environment.NewLine);
        fs.Write(bContent, 0, bContent.Length);
        fs.Flush();
    }
}
