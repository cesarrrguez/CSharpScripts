public interface IDatabase
{
    void Add(string data);
}

public class MySqlDatabase : IDatabase
{
    public void Add(string data)
    {
        Console.WriteLine($"Data \"{data}\" added to MySQL database");
    }
}

public class OracleDatabase : IDatabase
{
    public void Add(string data)
    {
        Console.WriteLine($"Data \"{data}\" added to Oracle database");
    }
}

public class Logic_DIP
{
    private readonly IDatabase _database;

    public Logic_DIP(IDatabase database)
    {
        _database = database;
    }

    public void RegisterData(string data)
    {
        _database.Add(data);
    }
}
