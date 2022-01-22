using Ardalis.SmartEnum;

public sealed class Subscriptions : SmartEnum<Subscriptions>
{
    public static readonly Subscriptions Free = new Subscriptions(nameof(Free), 1, .0);
    public static readonly Subscriptions Premium = new Subscriptions(nameof(Premium), 2, .25);
    public static readonly Subscriptions Ultimate = new Subscriptions(nameof(Ultimate), 3, .5);

    public double Discount { get; }

    public Subscriptions(string name, int value, double discount) : base(name, value)
    {
        Discount = discount;
    }
}
