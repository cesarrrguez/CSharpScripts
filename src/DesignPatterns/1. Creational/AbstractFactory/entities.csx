// Product A
public abstract class CreditCard
{
    public int CreditLimit { get; private set; }
    public int AnnualCharge { get; private set; }

    public void SetCreditLimit(int value) => CreditLimit = value;
    public void SetAnnualCharge(int value) => AnnualCharge = value;
    public abstract string GetName();
    public override string ToString() => $"Name: {GetName()}, Credit Limit: {CreditLimit}, Annual Charge: {AnnualCharge}";
}

// Product A1
public class TitaniumCreditCard : CreditCard
{
    public override string GetName() => "Titanium Credit Card";
}

// Product A2
public class PlatinumCreditCard : CreditCard
{
    public override string GetName() => "Platinum Credit Card";
}

// Product B
public abstract class Gift
{
    public double Price { get; private set; }

    public void SetPrice(double value) => Price = value;
    public abstract string GetName();
    public override string ToString() => $"Name: {GetName()}, Price: {Price}";
}

// Product B1
public class TitaniumGift : Gift
{
    public override string GetName() => "Titanium Gift";
}

// Product B2
public class PlatinumGift : Gift
{
    public override string GetName() => "Platinum Gift";
}
