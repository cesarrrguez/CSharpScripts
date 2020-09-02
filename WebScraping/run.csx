// HAPPY SCRAPING! :)

#load "utils.csx"
#load "entities.csx"

#r "nuget: ScrapySharp, 3.0.0"
#r "nuget: HtmlAgilityPack, 1.11.24"
#r "nuget: Flurl.Http, 2.4.2"

var startDate = new DateTime(2020, 08, 28);
var endDate = DateTime.Now;

Console.WriteLine("News\t\tImages");
Console.WriteLine("----\t\t------");
var saveNewsTask = App.RunSaveNews(startDate, endDate);
var saveImagesTask = App.RunSaveImages(startDate, endDate);

saveNewsTask.Wait();
saveImagesTask.Wait();

Console.WriteLine("\nScraping finished!");

public class App
{
    public async static Task RunSaveNews(DateTime startDate, DateTime endDate)
    {
        var path = "WebScraping/news.json";
        await Utils.SaveNews(startDate, endDate, path);
    }

    public async static Task RunSaveImages(DateTime startDate, DateTime endDate)
    {
        var path = "WebScraping/Images";
        FolderUtil.CleanupDirectory(path);
        await Utils.SaveImages(startDate, endDate, path);
    }
}
