#load "interfaces.csx"

public class DbSettings : IDbSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string UsersCollectionName { get; set; }
}
