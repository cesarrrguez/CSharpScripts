#load "interfaces.csx"

// Context
public class Beer
{
    private IBrewingStrategy _brewingStrategy;

    public Beer(IBrewingStrategy brewingStrategy)
    {
        _brewingStrategy = brewingStrategy;
    }

    public void SetBrewingStrategy(IBrewingStrategy brewingStrategy)
    {
        _brewingStrategy = brewingStrategy;
    }

    public void Brew()
    {
        _brewingStrategy.Brew();
    }
}
