// Product
public abstract class CreditCard
{
    public int CreditLimit { get; private set; }
    public int AnnualCharge { get; private set; }

    public void SetCreditLimit(int value) => CreditLimit = value;
    public void SetAnnualCharge(int value) => AnnualCharge = value;

    public abstract string GetName();

    public override string ToString() => $"Name: {GetName()}, Credit Limit: {CreditLimit}, Annual Charge: {AnnualCharge}";
}

// Product 1
public class TitaniumCreditCard : CreditCard
{
    public override string GetName() => "Titanium Credit Card";
}

// Product 2
public class PlatinumCreditCard : CreditCard
{
    public override string GetName() => "Platinum Credit Card";
}
