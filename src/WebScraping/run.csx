// HAPPY SCRAPING! :)

#load "utils.csx"
#load "entities.csx"

#r "nuget: ScrapySharp, 3.0.0"
#r "nuget: HtmlAgilityPack, 1.11.24"
#r "nuget: Flurl.Http, 2.4.2"

var startDate = new DateTime(2020, 08, 28);
var endDate = DateTime.Now;

WriteLine("News\t\tImages");
WriteLine("----\t\t------");
var saveNewsTask = App.RunSaveNewsAsync(startDate, endDate);
var saveImagesTask = App.RunSaveImagesAsync(startDate, endDate);

saveNewsTask.Wait();
saveImagesTask.Wait();

WriteLine("\nScraping finished!");

public static class App
{
    public async static Task RunSaveNewsAsync(DateTime startDate, DateTime endDate)
    {
        var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "news.json");
        await Utils.SaveNews(startDate, endDate, path).ConfigureAwait(false);
    }

    public async static Task RunSaveImagesAsync(DateTime startDate, DateTime endDate)
    {
        var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Images");
        FolderUtil.CleanupDirectory(path);
        await Utils.SaveImages(startDate, endDate, path).ConfigureAwait(false);
    }
}
