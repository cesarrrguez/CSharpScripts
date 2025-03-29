WriteLine($"Value: {Method()}");

public int Method()
{
    int y;
    LocalFunction();
    return y;

    void LocalFunction() => y = 7;
}
