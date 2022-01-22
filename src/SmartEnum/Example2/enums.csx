using Ardalis.SmartEnum;

public abstract class Subscriptions : SmartEnum<Subscriptions>
{
    public static readonly Subscriptions Free = new FreeTier();
    public static readonly Subscriptions Premium = new PremiumTier();
    public static readonly Subscriptions Ultimate = new UltimateTier();

    public abstract double Discount { get; }

    protected Subscriptions(string name, int value) : base(name, value)
    {
    }

    private sealed class FreeTier : Subscriptions
    {
        public override double Discount => .0;

        public FreeTier() : base("Free", 1) { }
    }

    private sealed class PremiumTier : Subscriptions
    {
        public override double Discount => .25;

        public PremiumTier() : base("Premium", 2) { }
    }

    private sealed class UltimateTier : Subscriptions
    {
        public override double Discount => .5;

        public UltimateTier() : base("Ultimate", 3) { }
    }
}
