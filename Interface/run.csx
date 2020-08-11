#load "entities.csx"

// Calculate Sum
CalculateOperation(1, 4.5, 6.7);

// Calculate Substract
CalculateOperation(2, 6.3, 3.4);

Console.WriteLine();

// Check if class implements an interface by exception
CheckInterfaceImplementationByException();

// Check if class implements an interface by as
CheckInterfaceImplementationByAs();

// Create an array of operations
var operations = new IOperation[] { new Sum(), new Subtract() };

foreach (var operation in operations)
{
    if (operation is Sum)
        Console.WriteLine("\nIs a Sum");

    if (operation is Subtract)
        Console.WriteLine("\nIs a Subtract");

    operation.Calculate(8, 3);
    operation.Show();
}

public void CalculateOperation(int option, double a, double b)
{
    IOperation operation = null;

    // Polymorphism
    if (option == 1)
    {
        operation = new Sum();
    }
    else if (option == 2)
    {
        operation = new Subtract();
    }

    operation.Calculate(a, b);
    operation.Show();
}

public void CheckInterfaceImplementationByException()
{
    var sum = new Sum();
    IOperation operation = null;

    try
    {
        operation = sum;
        operation.Check();
    }
    catch (System.InvalidCastException e)
    {
        Console.WriteLine(e.Message);
    }
}

public void CheckInterfaceImplementationByAs()
{
    var sum = new Sum();
    IOperation operation = null;

    operation = sum as IOperation;

    if (operation != null)
        operation.Check();
    else
        Console.WriteLine("Don´t implements IOperation");
}
