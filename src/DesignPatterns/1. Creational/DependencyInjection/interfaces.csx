// Service A
public interface IDatabase
{
    void Add(string data);
}

// Service B
public interface IDataService
{
    void RegisterData(string data);
}
