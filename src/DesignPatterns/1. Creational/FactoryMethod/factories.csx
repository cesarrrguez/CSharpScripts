#load "entities.csx"

// Creator
public abstract class CreditCardFactory
{
    protected abstract CreditCard Build(); // Factory Method
    public CreditCard GetObject() => Build();
}

// Creator 1
public class TitaniumCreditCardFactory : CreditCardFactory
{
    // Factory Method
    protected override CreditCard Build()
    {
        CreditCard creditCard = new TitaniumCreditCard();
        creditCard.SetCreditLimit(100000);
        creditCard.SetAnnualCharge(500);

        return creditCard;
    }
}

// Creator 2
public class PlatinumCreditCardFactory : CreditCardFactory
{
    // Factory Method
    protected override CreditCard Build()
    {
        CreditCard creditCard = new PlatinumCreditCard();
        creditCard.SetCreditLimit(500000);
        creditCard.SetAnnualCharge(1000);

        return creditCard;
    }
}
