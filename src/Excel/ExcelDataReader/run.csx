#load "entities.csx"
#load "services.csx"
#load "utils.csx"

#r "nuget: ExcelDataReader, 3.6.0"
#r "nuget: ExcelDataReader.DataSet, 3.6.0"

// .NET Core fix
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var excelService = new ExcelService();

// Read
var path = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Files/users.xlsx");

var users = excelService.ImportUsersFromExcel(path);
WriteLine($"Users: {string.Join(", ", users.ToList())}");
