// Mediator
public interface IMediator
{
    void Send(string message, Person person);
}

// Colleague
public abstract class Person
{
    protected readonly IMediator _mediator;

    protected Person(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public void Send(string message) => _mediator.Send(message, this);
    public abstract void Notify(string message);
}

// Colleague 1
public class User : Person
{
    public User(IMediator mediator) : base(mediator) { }
    public override void Notify(string message) => WriteLine($"User gets message: {message}");
}

// Colleague 2
public class Admin : Person
{
    public Admin(IMediator mediator) : base(mediator) { }
    public override void Notify(string message) => WriteLine($"Admin gets message: {message}");
}
