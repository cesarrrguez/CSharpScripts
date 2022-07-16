#load "entities.csx"

// Builder
public interface IFurnitureInventoryBuilder
{
    IFurnitureInventoryBuilder AddTitle();
    IFurnitureInventoryBuilder AddDimensions();
    IFurnitureInventoryBuilder AddLogistics(DateTime dateTime);
    InventoryReport GetDailyReport();
}
