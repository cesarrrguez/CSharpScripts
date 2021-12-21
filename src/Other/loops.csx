using System.Diagnostics.CodeAnalysis;

var numbers = new List<int> { 1, 2, 3, 4, 5 };

DoWhile();
WriteLine();

While();
WriteLine();

For();
WriteLine();

Foreach();
WriteLine();

ForeachMethod();
WriteLine();

ParallelForeach();
WriteLine();

Recursivity();
WriteLine();

Goto();
WriteLine();

LambdaExpression();
WriteLine();

Action executor = Closure();

public void DoWhile()
{
    int i = 0;

    do
    {
        Write(numbers[i]);
        i++;
    } while (i < numbers.Count);
}

[SuppressMessage("csharp", "RCS1239", Justification = "While use test")]
public void While()
{
    int i = 0;

    while (i < numbers.Count)
    {
        Write(numbers[i]);
        i++;
    }
}

public void For()
{
    for (int i = 0; i < numbers.Count; i++)
    {
        Write(numbers[i]);
    }
}

public void Foreach()
{
    foreach (var number in numbers)
    {
        Write(number);
    }
}

public void ForeachMethod()
{
    numbers.ForEach(number => Write(number));
}

public void ParallelForeach()
{
    Parallel.ForEach(numbers, number => Write(number));
}

public void Recursivity(int i = 0)
{
    if (i < numbers.Count)
    {
        Write(numbers[i]);
        i++;
        Recursivity(i);
    }
}

public void Goto()
{
    int i = 0;

Again:
    Write(numbers[i]);
    i++;

    if (i < numbers.Count)
    {
        goto Again;
    }
}

[SuppressMessage("csharp", "IDE0039", Justification = "Lambda expression test")]
public void LambdaExpression()
{
    int i = 0;
    Action action = null;

    action = () =>
    {
        if (i < numbers.Count)
        {
            Write(numbers[i]);
            i++;
            action();
        }
    };
}

[SuppressMessage("csharp", "IDE0039", Justification = "Closure test")]
public Action Closure()
{
    int i = 0;
    Action action = null;

    action = () =>
    {
        if (i < numbers.Count)
        {
            Write(numbers[i]);
            i++;
            action();
        }
    };

    return action;
}
