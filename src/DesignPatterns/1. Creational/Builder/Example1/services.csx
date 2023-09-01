#load "interfaces.csx"

// Director
public class SportsCarBuildDirector
{
    private readonly ICarBuilder _builder;

    public SportsCarBuildDirector(ICarBuilder builder)
    {
        _builder = builder;
    }

    public void Build()
    {
        _builder.Colour = "Red";
        _builder.NumDoors = 2;
    }
}
