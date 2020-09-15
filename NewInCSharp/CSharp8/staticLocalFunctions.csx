WriteLine($"Value: {Method()}");

public int Method()
{
    const int y = 5;
    const int x = 7;
    return Add(x, y);

    static int Add(int left, int right) => left + right;
}
