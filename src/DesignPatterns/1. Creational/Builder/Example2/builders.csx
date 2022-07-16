#load "interfaces.csx"

// Concrete Builder
public class DailyReportBuilder : IFurnitureInventoryBuilder
{
    private InventoryReport _report;
    private readonly IEnumerable<FurnitureItem> _items;

    public DailyReportBuilder(IEnumerable<FurnitureItem> items)
    {
        Reset();
        _items = items;
    }

    public IFurnitureInventoryBuilder AddTitle()
    {
        _report.TitleSection = "------- Daily Inventory Report -------\n\n";
        return this;
    }

    public IFurnitureInventoryBuilder AddDimensions()
    {
        _report.DimensionsSection = string.Join(Environment.NewLine, _items.Select(product =>
            $"Product: {product.Name} \nPrice: {product.Price} \n" +
            $"Height: {product.Height} x Width: {product.Width} -> Weight: {product.Weight} lbs \n"));

        return this;
    }

    public IFurnitureInventoryBuilder AddLogistics(DateTime dateTime)
    {
        _report.LogisticsSection = $"Report generated on {dateTime}";
        return this;
    }

    public InventoryReport GetDailyReport()
    {
        InventoryReport finishedReport = _report;
        Reset();

        return finishedReport;
    }

    public void Reset()
    {
        _report = new InventoryReport();
    }
}
