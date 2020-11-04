using System.Threading;

public class PCQ : IDisposable
{
    private readonly Queue<int?> _values = new Queue<int?>();

    private readonly object _control = new object();
    private readonly Thread _worker;
    private bool _exit;

    private readonly EventWaitHandle _waitHandle = new AutoResetEvent(false);

    public PCQ()
    {
        // Create and start new thread
        _worker = new Thread(Calculation);
        _worker.Start();
    }

    public void AddValue(int? value)
    {
        // Get value and enqueue it
        lock (_control) _values.Enqueue(value);

        // It can continue now
        _waitHandle.Set();
    }

    public void Dispose()
    {
        // Add null for ends thread
        AddValue(null);

        // Wait thread work
        _worker.Join();

        // Set wait handle free
        _waitHandle.Close();
    }

    public void Calculation()
    {
        while (!_exit)
        {
            int? value = null;

            // Critical section
            lock (_control)
            {
                if (_values.Count > 0)
                {
                    // Dequeue to next value
                    value = _values.Dequeue();

                    // With null ends work
                    if (value == null)
                    {
                        _exit = true;
                        return;
                    }
                }
            }

            if (value != null)
            {
                // Work section
                WriteLine("{0} * {0} = {1}", value, value * value);
                Thread.Sleep(1000);
            }
            else
            {
                WriteLine("Waiting, no values");

                // Wait signal
                _waitHandle.WaitOne();
            }
        }
    }
}
