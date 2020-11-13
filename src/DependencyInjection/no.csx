#load "entities.csx"

public class EmailClient
{
    public void Send(string email, string message)
    {
        WriteLine($"Email sent\n------------\nTo: {email}\nMessage: {message}\n");
    }
}

public class NewsLetterService
{
    private readonly EmailClient _emailClient = new EmailClient();

    public void SendNewsLetter(User user, Newsletter newsletter)
    {
        _emailClient.Send(user.Email, newsletter.Description);
    }
}
