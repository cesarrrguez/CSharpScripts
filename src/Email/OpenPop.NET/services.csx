using OpenPop.Pop3;

public class Pop3Service
{
    private readonly string _userName = "cesar.rrguez@gmail.com";
    private readonly string _password = "XXXXXXXXX"; // This is not the real password :)

    public List<OpenPop.Mime.Message> GetMessages()
    {
        using var client = new Pop3Client();

        client.Connect("pop.gmail.com", 995, true);
        client.Authenticate(_userName, _password);

        var messageCount = client.GetMessageCount();
        var messages = new List<OpenPop.Mime.Message>(messageCount);

        for (var i = messageCount; i > 0; i--)
        {
            messages.Add(client.GetMessage(i));
        }

        return messages;
    }
}
