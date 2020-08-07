using System.Net.Mail;
using System.Net;

var subject = "This is a subject";
var body = "This is the <strong>body</strong>";
var from = "cesar.rrguez@gmail.com";
var to = "cesar.rrguez@gmail.com";
var password = "XXXXXXXXX"; // This is not the real password :)

var mailMessage = new MailMessage(from, to, subject, body);
mailMessage.IsBodyHtml = true;

var smtpClient = new SmtpClient("smtp.gmail.com");
smtpClient.EnableSsl = true;
smtpClient.UseDefaultCredentials = false;
smtpClient.Credentials = new NetworkCredential(from, password);

smtpClient.Send(mailMessage);
smtpClient.Dispose();

Console.WriteLine("Email sent successfully");
