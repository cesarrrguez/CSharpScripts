public class Product
{
    public int Id { get; set; }
    public string Description { get; set; }

    public override string ToString() => $"Product. Id: {Id}, Description: {Description}";
}
