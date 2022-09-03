#load "records.csx"

#r "nuget: Ben.Demystifier, 0.4.1"

using System.Net.Http;
using System.Text.Json;

await Program.Run();

public static class Program
{
    public static async Task Run()
    {
        try
        {
            await RunAsync();
        }
        catch (Exception e)
        {
            WriteLine(e);
            WriteLine();
            WriteLine(e.Demystify());
        }
    }

    private static async Task RunAsync()
    {
        var GitHubUser = await GetGitHubUserAsync("cesarrrguez");
        var GitHubUserSerialized = JsonSerializer.Serialize(GitHubUser);
        WriteLine(GitHubUserSerialized);

        static async Task<GitHubUser> GetGitHubUserAsync(string username)
        {
            var GitHubUserText = await GetGitHubJsonAsync(username);
            return JsonSerializer.Deserialize<GitHubUser>(GitHubUserText);
        }
    }

    private static async Task<string> GetGitHubJsonAsync(string username)
    {
        var httpClient = new HttpClient(new HttpClientHandler());
        var response = await httpClient.GetAsync($"https://api.GitHub.com/users/{username}");
        ValidateRequest(response);
        return await response.Content.ReadAsStringAsync();
    }

    private static Action<HttpResponseMessage> ValidateRequest => message => message.EnsureSuccessStatusCode();
}
