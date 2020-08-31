public class News
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Author { get; private set; }
    public string Date { get; private set; }
    public string Link { get; private set; }
    public string ImageUrl { get; private set; }

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
