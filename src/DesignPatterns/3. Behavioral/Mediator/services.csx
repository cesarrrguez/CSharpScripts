#load "entities.csx"

// Concrete Mediator
public class ChatService : IMediator
{
    public User User;
    public Admin Admin;

    public void Send(string message, Person person)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        if (person == null) throw new ArgumentNullException(nameof(person));

        if (person == User)
        {
            Admin.Notify(message);
        }
        else
        {
            User.Notify(message);
        }
    }
}
