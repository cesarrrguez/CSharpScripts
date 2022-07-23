#r "nuget: PuppeteerSharp, 7.0.0"

using PuppeteerSharp;

await Program.Run();

public static class Program
{
    public static async Task Run()
    {
        const string url = "https://listado.mercadolibre.com.mx/cervezas#D[A:cervezas]";
        const string edge = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

        using var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();

        await using var browser = await Puppeteer.LaunchAsync(
            new LaunchOptions
            {
                Headless = true,
                ExecutablePath = edge
            }
        );

        await using var page = await browser.NewPageAsync();
        await page.GoToAsync(url);

        var titles = new List<string>();

        var result = await page.EvaluateFunctionAsync("() => {" +
            "const items = document.querySelectorAll('.ui-search-item__title');" +
            "const result = [];" +
            "for (let i = 0; i < items.length; i++)" +
            "   result.push(items[i].innerHTML);" +
            "return result;" +
            "}");

        result.ToList().ForEach(x => titles.Add(x.ToString()));

        titles.ForEach(x => WriteLine(x));
    }
}
