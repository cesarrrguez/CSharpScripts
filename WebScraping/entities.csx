public class News
{
    public string Title { get; }
    public string Description { get; }
    public string Author { get; }
    public string Date { get; }
    public string Link { get; }
    public string ImageUrl { get; }

    public News(string title, string description, string author, string date, string link, string imageUrl)
    {
        Title = title;
        Description = description;
        Author = author;
        Date = date;
        Link = link;
        ImageUrl = imageUrl;
    }
}
