#load "interfaces.csx"

// Abstraction
public abstract class AbstractAccount
{
    public ILogger Logger { get; set; }
    public int Balance { get; protected set; }

    protected AbstractAccount(ILogger logger, int balance)
    {
        Logger = logger;
        Balance = balance;
    }

    public void SendInfoMessage(string message) => Logger.Info(message);
    public void SendWarningMessage(string message) => Logger.Warning(message);

    public void SendConfirmation(string message, bool result)
    {
        if (result)
        {
            SendInfoMessage(message);
        }
        else
        {
            SendWarningMessage(message);
        }
    }

    public abstract void Withdraw(int amount);
}

// Refined Abstraction
public class SimpleAccount : AbstractAccount
{
    public SimpleAccount(ILogger logger, int balance) : base(logger, balance) { }

    public override void Withdraw(int amount)
    {
        var shouldPerform = Balance >= amount;

        if (shouldPerform)
        {
            Balance -= amount;
        }

        SendConfirmation("Withdraw " + amount, shouldPerform);
    }
}
