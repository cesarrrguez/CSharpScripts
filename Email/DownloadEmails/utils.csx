using OpenPop.Pop3;

public class Pop3Util
{
    private readonly string _username = "cesar.rrguez@gmail.com";
    private readonly string _pass = "XXXXXXXXX"; // This is not the real password :)
    private readonly string _hostname = "pop.gmail.com";
    private readonly int _port = 995;
    private readonly bool _useSsl = true;

    public List<OpenPop.Mime.Message> GetMessages()
    {
        using var client = new Pop3Client();

        client.Connect(_hostname, _port, _useSsl);
        client.Authenticate(_username, _pass);

        var messageCount = client.GetMessageCount();
        var messages = new List<OpenPop.Mime.Message>(messageCount);

        for (int i = messageCount; i > 0; i--)
        {
            messages.Add(client.GetMessage(i));
        }

        return messages;
    }
}
