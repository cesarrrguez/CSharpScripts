#load "records.csx"
#load "utils.csx"

using Flurl;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

public class NewsService
{
    private const string _domain = "https://www.lne.es";

    public async Task SaveNews(DateOnly startDate, DateOnly endDate, string path)
    {
        var news = new List<News>();
        var web = new HtmlWeb();

        for (var day = endDate; day >= startDate; day = day.AddDays(-1))
        {
            var url = GetUrlByDay(day);
            var doc = await web.LoadFromWebAsync(url);

            // Check no data
            if (!doc.DocumentNode.CssSelect(".news-module-subsection").Any()) continue;

            news.AddRange(GetNews(doc, day));

            WriteLine($"{day.ToShortDateString()}");
        }

        await WriteNews(news, path);
    }

    public async Task SaveImages(DateOnly startDate, DateOnly endDate, string path)
    {
        var web = new HtmlWeb();

        for (var day = endDate; day >= startDate; day = day.AddDays(-1))
        {
            var url = GetUrlByDay(day);
            var doc = await web.LoadFromWebAsync(url);

            // Check no data
            if (!doc.DocumentNode.CssSelect(".news-module-subsection").Any()) continue;

            await DownloadImages(doc, day, path);

            WriteLine($"\t\t{day.ToShortDateString()}");
        }
    }

    public void LoginForm()
    {
        var browser = new ScrapingBrowser
        {
            AllowAutoRedirect = true,
            AllowMetaRedirect = true
        };

        var web = browser.NavigateToPage(new Uri("https://micuenta.lne.es/login"));
        var form = web.FindFormById("login-form");
        form["email"] = "XXXXXXXXX";
        form["password"] = "XXXXXXXXX";
        form["remember_me"] = "1";

        form.Method = HttpVerb.Post;
        var result = form.Submit();

        WriteLine($"Status response: {result.RawResponse.StatusCode} - {result.RawResponse.StatusDescription}");
    }

    private string GetUrlByDay(DateOnly day)
    {
        return Url.Combine(_domain, $"asturias/{day.Year}/{day.Month.ToString().PadLeft(2, '0')}/{day.Day.ToString().PadLeft(2, '0')}");
    }

    private List<News> GetNews(HtmlDocument doc, DateOnly day)
    {
        var news = new List<News>();
        var nodes = doc.DocumentNode.CssSelect(".news-module-subsection .lst");

        foreach (var node in nodes)
        {
            var title = node.CssSelect(".lst__block h2").Single().InnerText;
            var author = string.Join(", ", node.CssSelect(".lst__block .new__author").Select(x => x?.Attributes["title"]?.Value));
            var date = day.ToShortDateString();
            var url = node.CssSelect(".lst__block a").First().Attributes["href"].Value;
            var imageUrl = node.CssSelect(".new__media .image source").LastOrDefault()?.Attributes["srcset"].Value ?? string.Empty;

            url = ParseUrl(url);
            imageUrl = ParseUrl(imageUrl);

            news.Add(new News(title, author, date, url, imageUrl));
        }

        return news;
    }

    private string ParseUrl(string url)
    {
        // Add domain to url if necessary
        if (!string.IsNullOrEmpty(url) && !url.StartsWith("http"))
        {
            url = Url.Combine(_domain, url);
        }

        // Remove parameters from url if necessary
        int urlIndex = url.IndexOf("?");
        if (urlIndex > 0)
        {
            url = url[0..urlIndex];
        }

        return url;
    }

    private async Task WriteNews(List<News> news, string path)
    {
        using var stream = File.Create(path);
        await JsonSerializer.SerializeAsync(stream, news, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
    }

    private async Task DownloadImages(HtmlDocument doc, DateOnly day, string path)
    {
        var nodes = doc.DocumentNode.CssSelect(".news-module-subsection .lst");

        var folderPath = Path.Combine(path, $"{day:yyyy_MM_dd}");
        FolderUtil.CreateFolder(folderPath);

        foreach (var node in nodes)
        {
            var imageUrl = node.CssSelect(".new__media .image source").LastOrDefault()?.Attributes["srcset"].Value ?? string.Empty;

            if (string.IsNullOrEmpty(imageUrl)) continue;

            imageUrl = ParseUrl(imageUrl);

            var imagePath = Path.Combine(folderPath, Path.GetFileName(imageUrl));

            if (File.Exists(imagePath)) continue;

            using HttpClient client = new HttpClient();
            using Stream stream = await client.GetStreamAsync(imageUrl);
            using FileStream fileStream = new FileStream(imagePath, FileMode.CreateNew);
            await stream.CopyToAsync(fileStream);
        }
    }
}
