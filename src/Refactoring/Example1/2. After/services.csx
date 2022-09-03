#load "utils.csx"
#load "entities.csx"
#load "interfaces.csx"

using System.Net.Http;
using Flurl;

public class ActionService<T> : IService<T>
{
    private readonly Action _action;

    public ActionService(Action action)
    {
        _action = action;
    }

    public async Task<T> GetAsync(int id)
    {
        var url = Url.Combine(EnvironmentUtil.URL, _action.ToString().ToLower(), id.ToString());

        var client = new HttpClient();
        var response = await client.GetAsync(url);

        return await response.Content.ReadAsAsync<T>();
    }
}
