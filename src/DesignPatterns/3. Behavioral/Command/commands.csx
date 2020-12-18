#load "entities.csx"
#load "services.csx"
#load "enums.csx"

// Concrete Command
public class ProductCommand : ICommand
{
    private readonly Product _product;
    private readonly PriceAction _priceAction;
    private readonly int _amount;

    public ProductCommand(Product product, PriceAction priceAction, int amount)
    {
        _product = product ?? throw new ArgumentNullException(nameof(product));
        _priceAction = priceAction;
        _amount = amount;
    }

    public void ExecuteAction()
    {
        if (_priceAction == PriceAction.Increase)
        {
            _product.IncreasePrice(_amount);
        }
        else
        {
            _product.DecreasePrice(_amount);
        }
    }
}
