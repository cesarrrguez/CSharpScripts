var byDefaultPrecedence = Operand("A", true) || (Operand("B", true) && Operand("C", false));
Console.WriteLine(byDefaultPrecedence);
Console.WriteLine();
// Output:
// Operand A is evaluated
// True

var changedOrder = (Operand("A", true) || Operand("B", true)) && Operand("C", false);
Console.WriteLine(changedOrder);
// Output:
// Operand A is evaluated
// Operand C is evaluated
// False

public bool Operand(string name, bool value)
{
    Console.WriteLine($"Operand {name} is evaluated");
    return value;
}
