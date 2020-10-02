using System.Threading;

Thread.CurrentThread.Name = "Main Thread";

var thread = new Thread(Message);
thread.Name = "Second Thread";
thread.Start("World");

WriteLine("Hello from '{0}' ({1})", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);

public void Message(object obj)
{
    WriteLine("Hello {0} from '{1}' ({2})", obj, Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
}
