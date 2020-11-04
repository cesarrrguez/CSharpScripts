public sealed class Pizza
{
    public int SizeDiameterCM { get; private set; }

    private Pizza()
    {
        SizeDiameterCM = 25;
    }

    public static Pizza GetPizza()
    {
        return new Pizza();
    }

    public static Pizza GetLargePizza()
    {
        return new Pizza()
        {
            SizeDiameterCM = 35
        };
    }

    public static Pizza GetSmallPizza()
    {
        return new Pizza()
        {
            SizeDiameterCM = 28
        };
    }

    public override string ToString()
    {
        return String.Format("A Pizza with a diameter of {0} cm", SizeDiameterCM);
    }
}
