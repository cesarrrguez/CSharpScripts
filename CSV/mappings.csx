#load "entities.csx"

using CsvHelper.Configuration;

public class UserMap : ClassMap<User>
{
    public UserMap()
    {
        Map(x => x.Name).Index(1);
        Map(x => x.Age).Index(0);
    }
}
