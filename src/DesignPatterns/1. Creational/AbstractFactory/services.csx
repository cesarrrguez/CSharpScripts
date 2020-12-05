#load "factories.csx"

// Client
public class ClientService
{
    private readonly CreditCard _creditCard;
    private readonly Gift _gift;

    public ClientService(BankFactory factory)
    {
        if (factory == null) throw new ArgumentNullException(nameof(factory));

        _creditCard = factory.GetCreditCardObject();
        _gift = factory.GetGiftObject();
    }

    public void Print()
    {
        WriteLine(_creditCard);
        WriteLine(_gift);
    }
}
