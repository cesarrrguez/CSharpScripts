#load "entities.csx"

public interface IMessageSender
{
    void Send(User user, string message);
}

public class EmailSender : IMessageSender
{
    public void Send(User user, string message)
    {
        Console.WriteLine($"Email sent\n------------\nTo: {user.Email}\nMessage: {message}\n");
    }
}

public class SmsSender : IMessageSender
{
    public void Send(User user, string message)
    {
        Console.WriteLine($"Sms sent\n------------\nTo: {user.Phone}\nMessage: {message}\n");
    }
}

public static class Factory
{
    public static IMessageSender CreateMessageSender()
    {
        //return new EmailSender();
        return new SmsSender();
    }
}

// Constructor injection
// ------------------------
public class NewsLetterService_DI
{
    private readonly IMessageSender _messageSender;

    public NewsLetterService_DI(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public void SendNewsLetter(User user, Newsletter newsletter)
    {
        _messageSender.Send(user, newsletter.Description);
    }
}

// Setter injection
// ------------------------
public class NewsLetterService_DI2
{
    private IMessageSender _messageSender;

    public void SetmessageSender(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public void SendNewsLetter(User user, Newsletter newsletter)
    {
        _messageSender.Send(user, newsletter.Description);
    }
}

// Method injection
// ------------------------
public class NewsLetterService_DI3
{
    public void SendNewsLetter(User user, Newsletter newsletter, IMessageSender messageSender)
    {
        messageSender.Send(user, newsletter.Description);
    }
}

// Interface injection
// ------------------------
public interface IMessageSenderInjector
{
    void Inject(IMessageSender messageSender);
}

public class NewsLetterService_DI4 : IMessageSenderInjector
{
    private IMessageSender _messageSender;

    public void Inject(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public void SendNewsLetter(User user, Newsletter newsletter)
    {
        _messageSender.Send(user, newsletter.Description);
    }
}
