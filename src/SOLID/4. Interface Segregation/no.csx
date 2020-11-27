public interface ISmartDevice
{
    void Print();
    void Fax();
    void Scan();
}

public class AllInOnePrinter : ISmartDevice
{
    public void Print() => WriteLine("Printing ...");
    public void Fax() => WriteLine("Fax ...");
    public void Scan() => WriteLine("Scanning ...");
}

public class EconomicPrinter : ISmartDevice
{
    public void Print() => WriteLine("Printing ...");
    public void Fax() => throw new NotSupportedException();
    public void Scan() => throw new NotSupportedException();
}
