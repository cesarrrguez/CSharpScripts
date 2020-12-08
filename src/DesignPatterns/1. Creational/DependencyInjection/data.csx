#load "interfaces.csx"

// Service A1
public class MySqlDatabase : IDatabase
{
    public void Add(string data) => WriteLine($"Data \"{data}\" added to MySQL database");
}

// Service A2
public class OracleDatabase : IDatabase
{
    public void Add(string data) => WriteLine($"Data \"{data}\" added to Oracle database");
}
