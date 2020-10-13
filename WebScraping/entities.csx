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
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Author = author ?? throw new ArgumentNullException(nameof(author));
        Date = date ?? throw new ArgumentNullException(nameof(date));
        Link = link ?? throw new ArgumentNullException(nameof(link));
        ImageUrl = imageUrl ?? throw new ArgumentNullException(nameof(imageUrl));
    }
}
