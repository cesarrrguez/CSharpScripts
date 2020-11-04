// Thread Pool
// ------------------------------------------------------------------------------
// Provides a pool of threads that can be used to execute tasks, post work items, 
// process asynchronous I/O, wait on behalf of other threads, and process timers.
// ------------------------------------------------------------------------------

#load "utils.csx"

using System.Threading;

for (int i = 0; i < 10; i++)
{
    ThreadPool.QueueUserWorkItem(Create, i);
}

while (ThreadPool.PendingWorkItemCount > 0) ;

public void Create(object data)
{
    int i = (int)data;
    var filePath = Path.Combine(FolderUtil.GetCurrentDirectoryName(), "Files/{i}.txt");
    var message = $"i: {i}, thread: {Thread.CurrentThread.ManagedThreadId}";

    using var sw = new StreamWriter(filePath);
    sw.WriteLine(message);

    WriteLine(message);
}
