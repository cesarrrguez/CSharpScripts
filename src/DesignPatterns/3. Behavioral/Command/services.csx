#load "interfaces.csx"
#load "entities.csx"

// Invoker
public class ModifyPrice
{
    private readonly List<ICommand> _commands;
    private ICommand _command;

    public ModifyPrice()
    {
        _commands = new List<ICommand>();
    }

    public void SetCommand(ICommand command) => _command = command;

    public void Invoke()
    {
        _commands.Add(_command);
        _command.ExecuteAction();
    }
}

// Client
public class Client
{
    public void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (productCommand == null) throw new ArgumentNullException(nameof(productCommand));

        modifyPrice.SetCommand(productCommand);
        modifyPrice.Invoke();
    }
}
