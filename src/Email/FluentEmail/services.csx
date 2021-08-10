using System.Net;
using System.Net.Mail;

using FluentEmail.Core;
using FluentEmail.Smtp;

public class MailService
{
    private readonly string _userName = "cesar.rrguez@gmail.com";
    private readonly string _password = "PerroAzul&21"; // This is not the real password :) XXXXXXXXX

    public MailService()
    {
        Email.DefaultSender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Port = 587,
            Credentials = new NetworkCredential(_userName, _password)
        });
    }

    public void SendMessage(string to, string subject, string bodyHtml, string bodyPlainText)
    {
        var email = Email
            .From(_userName)
            .To(to)
            .Subject(subject)
            .Body(bodyHtml, true)
            .PlaintextAlternativeBody(bodyPlainText);

        var response = email.Send();

        if (response.Successful)
        {
            WriteLine("Email sent successfully");
            return;
        }

        WriteLine("Error sending email");
        foreach (var error in response.ErrorMessages)
        {
            WriteLine(error);
        }
    }
}
