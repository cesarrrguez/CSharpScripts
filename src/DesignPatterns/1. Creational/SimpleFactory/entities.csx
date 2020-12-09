#load "interfaces.csx"

// Product 1
public class TitaniumCreditCard : ICreditCard
{
    public int CreditLimit => 100000;
    public int AnnualCharge => 500;
}

// Product 2
public class PlatinumCreditCard : ICreditCard
{
    public int CreditLimit => 500000;
    public int AnnualCharge => 1000;
}
