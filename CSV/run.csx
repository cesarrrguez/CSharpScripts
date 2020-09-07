#load "entities.csx"
#load "utils.csx"

#r "nuget: CsvHelper, 15.0.5"

// Read
var path = "CSV/Files/users1.csv";
var users = CsvUtil.ImportUsersFromCsv(path);
WriteLine($"Users: {string.Join(", ", users.ToList())}");

// Write
path = "CSV/Files/users2.csv";
CsvUtil.ExportUsersToCsv(users, path);
