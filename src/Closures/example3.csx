Action fn = Execute(2);
Run(fn);
Run(fn);
Run(fn);

public void Run(Action fn)
{
    WriteLine("START");
    fn();
    WriteLine("END");
}

public Action Execute(int number)
{
    int index = 0;
    WriteLine("Hello, I´m initialized");

    return () =>
    {
        if (index < number)
        {
            WriteLine("Execute ON");
        }
        else
        {
            WriteLine("Execute END");
        }

        index++;
    };
}
