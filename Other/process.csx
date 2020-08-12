using System.Threading;

Console.WriteLine("Processes:");
PrintProcesses();
Console.WriteLine();

PrintProcessById(15000);

Process process = InitProcess();
Thread.Sleep(10000);
KillProcess(process);

public void PrintProcesses()
{
    var processes = Process.GetProcesses().OrderBy(x => x.Id).ToList();

    foreach (var process in processes)
        Console.WriteLine("PID: {0}, Name: {1}", process.Id, process.ProcessName);
}

public void PrintProcessById(int pid)
{
    Process process = null;

    try
    {
        process = Process.GetProcessById(pid);
        Console.WriteLine("PID: {0}, Name: {1}", process.Id, process.ProcessName);

        // Get process threads
        var threads = process.Threads;

        foreach (ProcessThread thread in threads)
            Console.WriteLine("Thread ID: {0}, Start: {1}, Priority: {2}", thread.Id, thread.StartTime, thread.PriorityLevel);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

public Process InitProcess()
{
    Process process = null;

    try
    {
        process = Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "https://cesarrrguez.github.io/");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }

    return process;
}

public void KillProcess(Process process)
{
    try
    {
        process.Kill();
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
