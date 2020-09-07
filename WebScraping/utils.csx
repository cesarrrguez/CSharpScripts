#load "entities.csx"

using Flurl;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System.Globalization;
using System.Net;
using System.Text.Json;
using System.Threading;

public class Utils
{
    private const string _domain = @"https://www.lne.es";

    public static async Task SaveNews(DateTime startDate, DateTime endDate, string path)
    {
        var news = new List<News>();
        var web = new HtmlWeb();

        for (var day = endDate; day.Date >= startDate; day = day.AddDays(-1))
        {
            var url = Url.Combine(_domain, $"asturias/{day.Year}/{day.Month.ToString().PadLeft(2, '0')}/{day.Day.ToString().PadLeft(2, '0')}");
            var doc = await web.LoadFromWebAsync(url);

            // Check no data
            if (!doc.DocumentNode.CssSelect(".noticias").Any()) continue;

            var blocks = new string[] { ".noticia_destacada_portada", ".bloque_izquierdo", ".bloque_derecho" };
            foreach (var item in blocks)
            {
                BuildNews(doc, item, news, day);
            }

            Console.WriteLine($"{day.ToShortDateString()}");
        }

        await WriteNews(news, path);
    }

    private static void BuildNews(HtmlDocument doc, string expression, List<News> news, DateTime day)
    {
        var nodes = doc.DocumentNode.CssSelect(expression);
        var textInfo = new CultureInfo("es-Es", false).TextInfo;

        foreach (var node in nodes.CssSelect(".noticia"))
        {
            var title = node.CssSelect("[itemprop='headline'] a").FirstOrDefault()?.InnerText ?? string.Empty;
            var description = node.CssSelect("p[itemprop='description']").FirstOrDefault()?.InnerText ?? string.Empty;
            var author = textInfo.ToTitleCase(node.CssSelect("meta[itemprop='author']").FirstOrDefault()?.Attributes["content"]?.Value ?? string.Empty);
            var date = day.ToShortDateString();
            var link = node.CssSelect("[itemprop='headline'] a").FirstOrDefault()?.Attributes["href"]?.Value ?? string.Empty;
            var imageUrl = node.CssSelect("div[itemprop='image'] img").FirstOrDefault()?.Attributes["data-src"]?.Value ??
            node.CssSelect("div[itemprop='image'] .imagen").FirstOrDefault()?.Attributes["src"]?.Value ?? string.Empty;

            // Add domain to link if necessary
            if (!string.IsNullOrEmpty(link) && !link.StartsWith("http"))
            {
                link = Url.Combine(_domain, link);
            }

            // Add domain to image url if necessary
            if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.StartsWith("http"))
            {
                imageUrl = Url.Combine(_domain, imageUrl);
            }

            // Remove parameters from image url if necessary
            int imageUrlIndex = imageUrl.IndexOf("?");
            if (imageUrlIndex > 0)
            {
                imageUrl = imageUrl.Substring(0, imageUrlIndex);
            }

            news.Add(new News(title, description, author, date, link, imageUrl));
        }
    }

    private static async Task WriteNews(List<News> news, string path)
    {
        using var stream = File.Create(path);
        await JsonSerializer.SerializeAsync<List<News>>(stream, news, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
    }

    public static async Task SaveImages(DateTime startDate, DateTime endDate, string path)
    {
        var web = new HtmlWeb();

        for (var day = endDate; day.Date >= startDate; day = day.AddDays(-1))
        {
            var url = Url.Combine(_domain, $"asturias/{day.Year}/{day.Month.ToString().PadLeft(2, '0')}/{day.Day.ToString().PadLeft(2, '0')}");
            var doc = await web.LoadFromWebAsync(url);

            // Check no data
            if (!doc.DocumentNode.CssSelect(".noticias").Any()) continue;

            var blocks = new string[] { ".noticia_destacada_portada", ".bloque_izquierdo", ".bloque_derecho" };
            foreach (var item in blocks)
            {
                await DownloadImages(doc, item, day, path);
            }

            Console.WriteLine($"\t\t{day.ToShortDateString()}");
        }
    }

    private static async Task DownloadImages(HtmlDocument doc, string expression, DateTime day, string path)
    {
        var nodes = doc.DocumentNode.CssSelect(expression);

        var folderPath = Path.Combine(path, $"{day.ToString("yyyy_MM_dd")}/{expression.Replace(".", "")}");
        FolderUtil.CreateFolder(folderPath);

        foreach (var node in nodes.CssSelect(".noticia"))
        {
            var imageUrl = node.CssSelect("div[itemprop='image'] img").FirstOrDefault()?.Attributes["data-src"]?.Value ??
            node.CssSelect("div[itemprop='image'] .imagen").FirstOrDefault()?.Attributes["src"]?.Value ?? string.Empty;

            if (string.IsNullOrEmpty(imageUrl)) continue;

            // Add domain to image url if necessary
            if (!imageUrl.StartsWith("http"))
            {
                imageUrl = Url.Combine(_domain, imageUrl);
            }

            // Remove parameters from image url if necessary
            int imageUrlIndex = imageUrl.IndexOf("?");
            if (imageUrlIndex > 0)
            {
                imageUrl = imageUrl.Substring(0, imageUrlIndex);
            }

            using var client = new WebClient();
            var imagePath = Path.Combine(folderPath, Path.GetFileName(imageUrl));
            await client.DownloadFileTaskAsync(new Uri(imageUrl), imagePath);
        }
    }

    public static void LoginForm()
    {
        var browser = new ScrapingBrowser();
        browser.AllowAutoRedirect = true;
        browser.AllowMetaRedirect = true;

        var web = browser.NavigateToPage(new Uri("https://micuenta.lne.es/login"));
        var form = web.FindFormById("login-form");
        form["email"] = "XXXXXXXXX";
        form["password"] = "XXXXXXXXX";
        form["remember_me"] = "1";

        form.Method = HttpVerb.Post;
        var result = form.Submit();

        Console.WriteLine($"Status response: {result.RawResponse.StatusCode} - {result.RawResponse.StatusDescription}");
    }
}

public class FolderUtil
{
    public static void CreateFolder(string path)
    {
        if (Directory.Exists(path)) return;
        Directory.CreateDirectory(path);
    }

    public static void CleanupDirectory(string path)
    {
        const int tryCount = 3;

        for (var i = tryCount; i > 0; i--)
        {
            try
            {
                if (!Directory.Exists(path)) continue;

                var directoryInfo = new DirectoryInfo(path);
                var directories = directoryInfo.GetDirectories();

                if (!directories.Any()) continue;

                foreach (var directory in directories)
                {
                    directory.Delete(true);
                }
                break;
            }
            catch (Exception ex) when (i > 1)
            {
                Debug.WriteLine(ex);
                Thread.Sleep(1000);
            }
        }
    }
}
