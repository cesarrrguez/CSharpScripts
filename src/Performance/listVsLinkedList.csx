var stopwatch = new Stopwatch();

// List performance test
WriteLine("List performance test ...");
stopwatch.Start();
ListPerformanceTest();
stopwatch.Stop();
WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

// Linked list performance test
WriteLine("\nLinked list performance test ...");
stopwatch.Restart();
LinkedListPerformanceTest();
stopwatch.Stop();
WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

public void ListPerformanceTest()
{
    List<Temp> list = new List<Temp>(); // 2.4 seconds

    for (var i = 0; i < 12345678; i++)
    {
        var a = new Temp(i, i, i, i);
        list.Add(a);
    }

    decimal sum = 0;
    foreach (var item in list)
    {
        sum += item.A;
    }
}

public void LinkedListPerformanceTest()
{
    LinkedList<Temp> list = new LinkedList<Temp>();

    for (var i = 0; i < 12345678; i++)
    {
        var a = new Temp(i, i, i, i);
        list.AddLast(a);
    }

    decimal sum = 0;
    foreach (var item in list)
    {
        sum += item.A;
    }
}

public class Temp
{
    public decimal A, B, C, D;

    public Temp(decimal a, decimal b, decimal c, decimal d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }
}
