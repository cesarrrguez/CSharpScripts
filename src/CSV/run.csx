#load "../../packages.csx"

#load "entities.csx"
#load "services.csx"
#load "utils.csx"

var csvService = new CsvService();

// Read
var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Files/users_1.csv");

var users = csvService.ImportUsersFromCsv(path);
WriteLine($"Users: {string.Join(", ", users.ToList())}");

// Write
path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Files/users_2.csv");
csvService.ExportUsersToCsv(users, path);
