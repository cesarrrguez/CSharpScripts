// Abstract Class
public abstract class DataAccessObject
{
    protected List<string> dataSet;

    public abstract void Select();
    public abstract void Process();

    public void Connect() => WriteLine("Database connection established");
    public void Disconnect() => WriteLine("Database connection ended");

    // The 'Template Method' 
    public void Run()
    {
        Connect();
        Select();
        Process();
        Disconnect();
    }
}

// Concrete Class 1
public class CategoryDAO : DataAccessObject
{
    public override void Select()
    {
        WriteLine("SQL: SELECT name from Categories");
        dataSet = new List<string>() { "Technology", "Food", "Clothing" };
    }

    public override void Process() => WriteLine($"Categories: {string.Join(", ", dataSet)}");
}

// Concrete Class 2
public class ProductDAO : DataAccessObject
{
    public override void Select()
    {
        WriteLine("SQL: SELECT name from Products");
        dataSet = new List<string>() { "Phone", "Apple", "Trousers" };
    }

    public override void Process() => WriteLine($"Products: {string.Join(", ", dataSet)}");
}
