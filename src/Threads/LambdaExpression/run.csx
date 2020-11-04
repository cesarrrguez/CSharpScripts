using System.Threading;

var thread = new Thread(() => Sum(3, 7));
thread.Start();

for (int i = 0; i < 10; i++)
{
    int temp = i;  // local variable needed
    var thread = new Thread(() => Write("{0} ", temp));
    thread.Start();
}

public void Sum(int obj1, int obj2)
{
    WriteLine("{0} + {1} = {2}", obj1, obj2, obj1 + obj2);
}
