#load "entities.csx"
#load "services.csx"

#r "nuget: CsvHelper, 15.0.5"

var csvService = new CsvService();

// Read
var path = "CSV/Files/users_1.csv";
var users = csvService.ImportUsersFromCsv(path);
WriteLine($"Users: {string.Join(", ", users.ToList())}");

// Write
path = "CSV/Files/users_2.csv";
csvService.ExportUsersToCsv(users, path);
