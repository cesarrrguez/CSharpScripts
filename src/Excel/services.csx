#load "entities.csx"

using System.Data;
using SpreadsheetLight;

public class ExcelService
{
    public List<User> ImportUsersFromExcel(string path)
    {
        var users = new List<User>();
        var document = new SLDocument(path);

        for (var i = 2; !string.IsNullOrEmpty(document.GetCellValueAsString(i, 1)); i++)
        {
            var name = document.GetCellValueAsString(i, 1);
            var age = document.GetCellValueAsInt32(i, 2);

            users.Add(new User(name, age));
        }

        return users;
    }

    public void ExportUsersToExcel(List<User> users, string path)
    {
        var document = new SLDocument();
        var dt = new DataTable();

        // Columns
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Age", typeof(int));

        // Rows
        users.ForEach(user => dt.Rows.Add(user.Name, user.Age));

        document.ImportDataTable(1, 1, dt, true);
        document.SaveAs(path);
    }
}
