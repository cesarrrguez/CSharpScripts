var counter = Counter();
counter.Increment();
counter.Increment();
WriteLine(counter.Get());

counter.Substract();
WriteLine(counter.Get());

public (Action Increment, Action Substract, Func<int> Get) Counter()
{
    int i = 0;

    void increment() => i++;
    void substract() => i--;
    int get() => i;

    return (increment, substract, get);
}
