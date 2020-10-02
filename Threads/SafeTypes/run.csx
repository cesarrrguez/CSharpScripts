using System.Threading;

var values = new List<int>();

var thread1 = new Thread(Add);
var thread2 = new Thread(Add);

thread1.Start();
thread2.Start();

Thread.Sleep(1000);

lock (values)
{
    foreach (var item in values)
    {
        WriteLine(item);
    }
}

public void Add()
{
    var rnd = new Random();

    lock (values)
    {
        values.Add(rnd.Next(1, 100));
    }
}
