#load "interfaces.csx"

// Service B1
public class Service : IDataService
{
    private readonly IDatabase _database;

    public Service(IDatabase database)
    {
        _database = database;
    }

    public void RegisterData(string data) => _database.Add(data);
}
