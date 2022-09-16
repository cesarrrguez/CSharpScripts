using System.ComponentModel;
using System.Threading;

App.Run();

public static class App
{
    public static BackgroundWorker Worker;

    public static void Run()
    {
        Worker = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        Worker.DoWork += Work;
        Worker.ProgressChanged += ShowProgress;
        Worker.RunWorkerCompleted += Finalize;

        Worker.RunWorkerAsync("Start work");

        WriteLine("Press any key to cancel");

        ReadLine();

        if (Worker.IsBusy)
        {
            Worker.CancelAsync();
            ReadLine();
        }
    }

    public static void Work(object sender, DoWorkEventArgs e)
    {
        WriteLine(e.Argument);

        var result = 0;

        for (var i = 0; i < 100; i++)
        {
            if (Worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            result += i;
            Thread.Sleep(100);

            Worker.ReportProgress(i);
        }

        e.Result = result;
    }

    public static void ShowProgress(object sender, ProgressChangedEventArgs e)
    {
        if (e.ProgressPercentage % 5 == 0)
        {
            WriteLine("{0} % completed", e.ProgressPercentage);
        }
    }

    public static void Finalize(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            WriteLine("Work canceled");
        }
        else if (e.Error != null)
        {
            WriteLine("Error {0}", e.Error.ToString());
        }
        else
        {
            WriteLine("Work completed");
            WriteLine(e.Result);
            WriteLine("Press any key to continue");
        }
    }
}
