#load "interfaces.csx"
#load "entities.csx"

public class SqlContext : IDataContext
{
    public void AddRow(string table, object value)
    {
        Console.WriteLine($"{table} [{value}] added to sql database");
    }

    public void DeleteRow(string table, Guid value)
    {
        Console.WriteLine($"{table} [{value}] deleted from sql database");
    }
}

public class XmlContext : IDataContext
{
    public void AddRow(string table, object value)
    {
        Console.WriteLine($"{table} [{value}] added to XML document");
    }

    public void DeleteRow(string table, Guid value)
    {
        Console.WriteLine($"{table} [{value}] deleted from XML document");
    }
}

public class UserRepository : IRepository<User>
{
    private readonly IDataContext _dataContext;

    public UserRepository(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void Add(User user)
    {
        _dataContext.AddRow(nameof(User), user);
    }

    public void Delete(Guid userId)
    {
        _dataContext.DeleteRow(nameof(User), userId);
    }
}
