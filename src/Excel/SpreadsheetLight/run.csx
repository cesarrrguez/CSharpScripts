#load "entities.csx"
#load "services.csx"
#load "utils.csx"

#r "nuget: SpreadsheetLight, 3.5.0"

var excelService = new ExcelService();

// Read
var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Files/users_1.xlsx");

var users = excelService.ImportUsersFromExcel(path);
WriteLine($"Users: {string.Join(", ", users.ToList())}");

// Write
path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Files/users_2.xlsx");
excelService.ExportUsersToExcel(users, path);
