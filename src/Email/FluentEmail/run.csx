#load "services.csx"

#r "nuget: FluentEmail.Core, 3.0.0"
#r "nuget: FluentEmail.Smtp, 3.0.0"

var mailService = new MailService();

var subject = "Test email subject";
var bodyHtml = "<p>Test email <strong>body</strong></p>";
var bodyPlainText = "<p>Test email <strong>body</strong></p>";
var to = "cesar.rrguez@gmail.com";

mailService.SendMessage(to, subject, bodyHtml, bodyPlainText);
