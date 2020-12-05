#load "entities.csx"

// Abstract Factory
public abstract class BankFactory
{
    protected abstract CreditCard BuildCreditCard();  // Create Product A
    protected abstract Gift BuildGift(); // Create Product B

    public CreditCard GetCreditCardObject() => BuildCreditCard();
    public Gift GetGiftObject() => BuildGift();
}

// Factory 1
public class TitaniumFactory : BankFactory
{
    // Create Product A
    protected override CreditCard BuildCreditCard()
    {
        CreditCard creditCard = new TitaniumCreditCard();
        creditCard.SetCreditLimit(100000);
        creditCard.SetAnnualCharge(500);

        return creditCard;
    }

    // Create Product B
    protected override Gift BuildGift()
    {
        Gift gift = new TitaniumGift();
        gift.SetPrice(100);

        return gift;
    }
}

// Factory 2
public class PlatinumFactory : BankFactory
{
    // Create Product A
    protected override CreditCard BuildCreditCard()
    {
        CreditCard creditCard = new PlatinumCreditCard();
        creditCard.SetCreditLimit(500000);
        creditCard.SetAnnualCharge(1000);

        return creditCard;
    }

    // Create Product B
    protected override Gift BuildGift()
    {
        Gift gift = new PlatinumGift();
        gift.SetPrice(200);

        return gift;
    }
}
