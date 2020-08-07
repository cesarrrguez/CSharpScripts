#load "entities.csx"

CalculateOperation(1, 4.5, 6.7);
CalculateOperation(2, 6.3, 3.4);

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
