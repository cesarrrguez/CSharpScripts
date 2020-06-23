public interface IPrinter
{
    void Print();
}

public interface IFax
{
    void Fax();
}
public interface IScanner
{
    void Scan();
}

public class AllInOnePrinter_ISP : IPrinter, IFax, IScanner
{
    public void Print()
    {
        Console.WriteLine("Printing ...");
    }
    public void Fax()
    {
        Console.WriteLine("Faxing ...");
    }
    public void Scan()
    {
        Console.WriteLine("Scanning ...");
    }
}

public class EconomicPrinter_ISP : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Printing ...");
    }
}
