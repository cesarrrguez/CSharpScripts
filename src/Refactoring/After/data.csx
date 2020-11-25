#load "utils.csx"
#load "entities.csx"
#load "interfaces.csx"

using Flurl;

public class ActionRepository<T> : IRepository<T>
{
    private readonly Action _action;

    public ActionRepository(Action action)
    {
        _action = action;
    }

    public async Task Save(string data)
    {
        var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Files", $"{_action.ToString().ToLower()}.txt");

        using var stream = File.Create(path);
        byte[] buffer = new UTF8Encoding(true).GetBytes(data);
        await stream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
    }
}
