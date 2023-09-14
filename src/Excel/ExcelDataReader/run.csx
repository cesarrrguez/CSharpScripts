#load "../../../packages.csx"

#load "entities.csx"
#load "services.csx"
#load "utils.csx"

// .NET Core fix
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var excelService = new ExcelService();

// Read
var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Files/users.xlsx");

var users = excelService.ImportUsersFromExcel(path);
WriteLine($"Users: {string.Join(", ", users.ToList())}");
