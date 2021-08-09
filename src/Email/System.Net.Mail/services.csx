using System.Net;
using System.Net.Mail;

public class MailService
{
    private readonly string _userName = "cesar.rrguez@gmail.com";
    private readonly string _password = "XXXXXXXXX"; // This is not the real password :)

    public void SendMessage(string to, string subject, string body, string filePath = null)
    {
        var mailMessage = new MailMessage(_userName, to, subject, body)
        {
            IsBodyHtml = true
        };

        if (!string.IsNullOrWhiteSpace(filePath))
        {
            mailMessage.Attachments.Add(new Attachment(filePath));
        }

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Port = 587,
            Credentials = new NetworkCredential(_userName, _password)
        };

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
    }
}
