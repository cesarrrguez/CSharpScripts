// HAPPY SCRAPING! :)

#load "services.csx"
#load "utils.csx"
#load "records.csx"

#r "nuget: Flurl.Http, 2.4.2"
#r "nuget: ScrapySharp, 3.0.0"
#r "nuget: HtmlAgilityPack, 1.11.24"

var startDate = new DateOnly(2022, 01, 21);
var endDate = DateOnly.FromDateTime(DateTime.Now);

WriteLine("News\t\tImages");
WriteLine("----\t\t------");

await App.RunSaveNewsAsync(startDate, endDate);
await App.RunSaveImagesAsync(startDate, endDate);

WriteLine("\nScraping finished!");

public static class App
{
    public async static Task RunSaveNewsAsync(DateOnly startDate, DateOnly endDate)
    {
        var newsService = new NewsService();
        var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "news.json");
        await newsService.SaveNews(startDate, endDate, path);
    }

    public async static Task RunSaveImagesAsync(DateOnly startDate, DateOnly endDate)
    {
        var newsService = new NewsService();
        var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Images");
        FolderUtil.CleanupDirectory(path);
        await newsService.SaveImages(startDate, endDate, path);
    }
}
