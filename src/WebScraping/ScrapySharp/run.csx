#load "../../../packages.csx"

#load "services.csx"
#load "utils.csx"
#load "records.csx"

// HAPPY SCRAPING! :)

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
