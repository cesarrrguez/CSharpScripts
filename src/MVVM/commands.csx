using System.Windows.Input;

public class DelegateCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;

    public DelegateCommand(Action execute, Func<bool> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute ?? (() => true);
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return _canExecute();
    }

    public void Execute(object parameter)
    {
        _execute();
    }

    public void NotifyCanExecuteChanged()
    {
        var handler = CanExecuteChanged;
        handler?.Invoke(this, EventArgs.Empty);
    }
}

public class DelegateCommand<T> : ICommand
{
    private readonly Action<T> _execute;
    private readonly Func<T, bool> _canExecute;

    public DelegateCommand(Action<T> execute, Func<T, bool> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return _canExecute((T)parameter);
    }

    public void Execute(object parameter)
    {
        _execute((T)parameter);
    }

    public void NotifyCanExecuteChanged()
    {
        var handler = CanExecuteChanged;
        handler?.Invoke(this, EventArgs.Empty);
    }
}
