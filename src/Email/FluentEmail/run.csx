#load "../../../packages.csx"

#load "services.csx"

var mailService = new MailService();

var subject = "Test email subject";
var bodyHtml = "<p>Test email <strong>body</strong></p>";
var bodyPlainText = "<p>Test email <strong>body</strong></p>";
var to = "cesar.rrguez@gmail.com";

mailService.SendMessage(to, subject, bodyHtml, bodyPlainText);
