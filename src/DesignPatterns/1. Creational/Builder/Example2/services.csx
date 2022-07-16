#load "interfaces.csx"

// Director
public class InventoryBuildDirector
{
    private readonly IFurnitureInventoryBuilder _builder;

    public InventoryBuildDirector(IFurnitureInventoryBuilder builder)
    {
        _builder = builder;
    }

    public void BuildCompleteReport()
    {
        _builder.AddTitle();
        _builder.AddDimensions();
        _builder.AddLogistics(DateTime.Now);
    }
}
