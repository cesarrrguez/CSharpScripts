#load "entities.csx"
#load "mappings.csx"

using System.Globalization;
using CsvHelper;

public static class CsvUtil
{
    public static List<User> ImportUsersFromCsv(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        return csv.GetRecords<User>().ToList();
    }

    public static void ExportUsersToCsv(List<User> users, string path)
    {
        using var writer = new StreamWriter(path);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csv.Configuration.RegisterClassMap<UserMap>();
        csv.WriteRecords(users);
    }
}
