#load "entities.csx"
#load "enums.csx"

// Creator
public static class CreditCardFactory
{
    public static ICreditCard Build(CreditCardType type) => type switch
    {
        CreditCardType.Titanium => new TitaniumCreditCard(),
        CreditCardType.Platinum => new PlatinumCreditCard(),
        _ => throw new NotSupportedException(),
    };
}
