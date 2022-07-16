// Product
public class FurnitureItem
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Weight { get; set; }

    public FurnitureItem(string name, double price, double height, double width, double weight)
    {
        Name = name;
        Price = price;
        Height = height;
        Width = width;
        Weight = weight;
    }
}

public class InventoryReport
{
    public string TitleSection { get; set; }
    public string DimensionsSection { get; set; }
    public string LogisticsSection { get; set; }

    public string Debug()
    {
        return new StringBuilder()
            .AppendLine(TitleSection)
            .AppendLine(DimensionsSection)
            .AppendLine(LogisticsSection)
            .ToString();
    }
}
