#load "commands.csx"
#load "processes.csx"
#load "utils.csx"

using System.ComponentModel;
using System.Windows.Input;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ProcessController _processController;

    // Bindings
    private bool _canClose;
    public bool CanClose
    {
        get => _canClose;

        set
        {
            if (value == _canClose) return;

            _canClose = value;
            OnCanCloseChanged();
            NotifyPropertyChanged(nameof(CanClose));
        }
    }

    // Commands
    private readonly DelegateCommand runCommand;
    public ICommand RunCommand => runCommand;

    private readonly DelegateCommand<CancelEventArgs> closeCommand;
    public ICommand CloseCommand => closeCommand;

    public MainViewModel()
    {
        _canClose = true;
        _processController = ProcessController.Instance;

        // Commands
        runCommand = new DelegateCommand(ExecuteRun, CanExecuteRun);
        closeCommand = new DelegateCommand<CancelEventArgs>(ExecuteClose, CanExecuteClose);
    }

    // Run
    public async void ExecuteRun()
    {
        Console.WriteLine("Running!");

        try
        {
            var input = new RunInput { Value1 = 5, Value2 = 7 };
            var output = await _processController.Specific.Run.ExecuteProcess(input).ConfigureAwait(false);

            if (output != null)
            {
                Console.WriteLine(output);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            UpdateCommands();
        }
    }

    public bool CanExecuteRun()
    {
        return true;
    }

    // Close
    public void ExecuteClose(CancelEventArgs e)
    {
        bool close = new Random().Next(0, 2) > 0;

        if (!close)
        {
            e.Cancel = true;
            Console.WriteLine("Not yet!");
        }
        else
        {
            e.Cancel = false;
            Console.WriteLine("Goodbye!");
        }
    }

    public bool CanExecuteClose(CancelEventArgs e)
    {
        return CanClose;
    }

    private void OnCanCloseChanged()
    {
        closeCommand.NotifyCanExecuteChanged();
    }

    // Update commands
    private void UpdateCommands()
    {
        runCommand.NotifyCanExecuteChanged();
        closeCommand.NotifyCanExecuteChanged();
    }

    // NotifyPropertyChanged
    protected void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler PropertyChanged;
}
