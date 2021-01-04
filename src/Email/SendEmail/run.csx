using System.Net.Mail;
using System.Net;

var subject = "Test email subject";
var body = "<p>Test email <strong>body</strong></p>";
var from = "cesar.rrguez@gmail.com";
var to = "cesar.rrguez@gmail.com";
var password = "*************";
var smtp = "smtp.gmail.com";

var mailMessage = new MailMessage(from, to, subject, body);
mailMessage.IsBodyHtml = true;

var smtpClient = new SmtpClient(smtp);
smtpClient.EnableSsl = true;
smtpClient.UseDefaultCredentials = false;
smtpClient.Port = 587;
smtpClient.Credentials = new NetworkCredential(from, password);

try
{
    smtpClient.Send(mailMessage);
    WriteLine("Email sent successfully");
}
catch (Exception e)
{
    WriteLine("Error sending email'");
    WriteLine(e.Message);
}
finally
{
    smtpClient.Dispose();
}
