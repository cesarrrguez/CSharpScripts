#load "records.csx"

#r "nuget: Ben.Demystifier, 0.4.1"

using System.Net.Http;
using System.Text.Json;

await Program.Run().ConfigureAwait(false);

public static class Program
{
    public static async Task Run()
    {
        try
        {
            await RunAsync().ConfigureAwait(false);
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
        var GitHubUser = await GetGitHubUserAsync("cesarrrguez").ConfigureAwait(false);
        var GitHubUserSerialized = JsonSerializer.Serialize(GitHubUser);
        WriteLine(GitHubUserSerialized);

        static async Task<GitHubUser> GetGitHubUserAsync(string username)
        {
            var GitHubUserText = await GetGitHubJsonAsync(username).ConfigureAwait(false);
            return JsonSerializer.Deserialize<GitHubUser>(GitHubUserText);
        }
    }

    private static async Task<string> GetGitHubJsonAsync(string username)
    {
        var httpClient = new HttpClient(new HttpClientHandler());
        var response = await httpClient.GetAsync($"https://api.GitHub.com/users/{username}").ConfigureAwait(false);
        ValidateRequest(response);
        return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
    }

    private static Action<HttpResponseMessage> ValidateRequest => message => message.EnsureSuccessStatusCode();
}
