#load "entities.csx"

// Calculate Sum
CalculateOperation(1, 4.5, 6.7);

// Calculate Substract
CalculateOperation(2, 6.3, 3.4);

WriteLine();

// Check if class implements an interface
CheckInterfaceImplementation();

// Create an array of operations
var operations = new IOperation[] { new Sum(), new Subtract() };

foreach (var operation in operations)
{
    if (operation is Sum)
    {
        WriteLine("\nIs a Sum");
    }

    if (operation is Subtract)
    {
        WriteLine("\nIs a Subtract");
    }

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

public void CheckInterfaceImplementation()
{
    var sum = new Sum();

    if (sum is IOperation operation)
    {
        operation.Check();
    }
    else
    {
        WriteLine("Don´t implements IOperation");
    }
}
