#load "services.csx"
#load "utils.csx"

var mailService = new MailService();

var subject = "Test email subject";
var body = "<p>Test email <strong>body</strong></p>";
var to = "cesar.rrguez@gmail.com";

mailService.SendMessage(to, subject, body);

var filePath = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "file.txt");
mailService.SendMessage(to, subject, body, filePath);
