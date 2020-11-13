public class MongoDB
{
    public void Add(string data)
    {
        WriteLine($"Data \"{data}\" added to MongoDB database");
    }
}

public class Logic
{
    private readonly MongoDB _database;

    public Logic()
    {
        _database = new MongoDB();
    }
    public void RegisterData(string data)
    {
        _database.Add(data);
    }
}
