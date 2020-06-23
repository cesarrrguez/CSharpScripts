public interface ISmartDevice
{
    void Print();
    void Fax();
    void Scan();
}

public class AllInOnePrinter : ISmartDevice
{
    public void Print()
    {
        Console.WriteLine("Printing ...");
    }
    public void Fax()
    {
        Console.WriteLine("Fax ...");
    }
    public void Scan()
    {
        Console.WriteLine("Scanning ...");
    }
}

public class EconomicPrinter : ISmartDevice
{
    public void Print()
    {
        Console.WriteLine("Printing ...");
    }
    public void Fax()
    {
        throw new NotSupportedException();
    }
    public void Scan()
    {
        throw new NotSupportedException();
    }
}
