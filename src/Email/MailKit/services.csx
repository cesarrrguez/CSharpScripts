using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;

using MimeKit;

public class MailService
{
    private readonly string _userName = "cesar.rrguez@gmail.com";
    private readonly string _password = "XXXXXXXXX"; // This is not the real password :)

    public void SendMessage(string fromName, string fromAddress, string toName, string toAddress, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(fromName, fromAddress));
        message.To.Add(new MailboxAddress(toName, toAddress));
        message.Subject = subject;

        message.Body = new TextPart("html")
        {
            Text = body
        };

        using var client = new SmtpClient();

        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate(_userName, _password);

        client.Send(message);

        client.Disconnect(true);
    }

    public List<MimeMessage> GetMessagesPop3()
    {
        using var client = new Pop3Client();

        client.Connect("pop.gmail.com", 995, true);
        client.Authenticate(_userName, _password);

        var messages = new List<MimeMessage>();

        for (var i = 0; i < client.Count; i++)
        {
            messages.Add(client.GetMessage(i));
        }

        client.Disconnect(true);

        return messages;
    }

    public List<MimeMessage> GetMessagesImap()
    {
        using var client = new ImapClient();

        client.Connect("imap.gmail.com", 993, true);
        client.Authenticate(_userName, _password);

        var inbox = client.Inbox;
        inbox.Open(FolderAccess.ReadOnly);

        WriteLine($"Total messages: {inbox.Count}");
        WriteLine($"Recent messages: {inbox.Recent}");

        var messages = new List<MimeMessage>();

        for (var i = 0; i < inbox.Count; i++)
        {
            messages.Add(inbox.GetMessage(i));
        }

        client.Disconnect(true);

        return messages;
    }
}
