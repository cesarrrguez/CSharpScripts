#load "entities.csx"

using System.Data;
using ExcelDataReader;

public class ExcelService
{
    public List<User> ImportUsersFromExcel(string path)
    {
        var users = new List<User>();

        using var stream = File.Open(path, FileMode.Open, FileAccess.Read);
        using var reader = ExcelReaderFactory.CreateReader(stream);

        var worksheet = reader.AsDataSet(new ExcelDataSetConfiguration()
        {
            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
            {
                UseHeaderRow = true
            }
        }).Tables[0];

        var rows = (from DataRow r in worksheet.Rows select r).ToList();

        for (var i = 1; i < rows.Count - 1; i++)
        {
            var name = rows[i].ItemArray[0].ToString();
            var age = Convert.ToInt32(rows[i].ItemArray[1]);

            users.Add(new User(name, age));
        }

        return users;
    }
}
