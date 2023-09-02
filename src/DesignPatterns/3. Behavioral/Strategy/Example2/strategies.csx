#load "interfaces.csx"

// Strategy A
public class AleBrewingStrategy : IBrewingStrategy
{
    public void Brew()
    {
        WriteLine("Ale Brewing Strategy");
    }
}

// Strategy B
public class LagerBrewingStrategy : IBrewingStrategy
{
    public void Brew()
    {
        WriteLine("Lager Brewing Strategy");
    }
}
