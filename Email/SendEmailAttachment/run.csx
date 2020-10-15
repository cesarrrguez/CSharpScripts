using System.Net.Mail;
using System.Net;

var subject = "This is a subject";
var body = "This is the <strong>body</strong>";
var from = "cesar.rrguez@gmail.com";
var to = "cesar.rrguez@gmail.com";
var password = "XXXXXXXXX"; // This is not the real password :)
var smtp = "smtp.gmail.com";

var mailMessage = new MailMessage(from, to, subject, body);
mailMessage.IsBodyHtml = true;

var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Email\\SendEmailAttachment\\file.txt");
mailMessage.Attachments.Add(new Attachment(filePath));

var smtpClient = new SmtpClient(smtp);
smtpClient.EnableSsl = true;
smtpClient.UseDefaultCredentials = false;
smtpClient.Port = 587;
smtpClient.Credentials = new NetworkCredential(from, password);

smtpClient.Send(mailMessage);
smtpClient.Dispose();

WriteLine("Email sent successfully");
