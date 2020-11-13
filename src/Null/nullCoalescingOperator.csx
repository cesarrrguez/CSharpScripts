// The null coalescing operator returns left-hand operand if the operand is not null, 
// and if it is, the right-hand operand is returned. Using this operator, we can avoid 
// Null Reference Exception, which is thrown when we try to use something that is null.

string variable = string.Empty;
string message = string.Empty;

variable = "Not null";
message = variable ?? "Default message if variable is null";
WriteLine($"{message}");

variable = null;
message = variable ?? "Default message if variable is null";
WriteLine($"{message}");

// Using the null coalesce operator and parentheses to automatically instantiate collections
ListOfNumbers.Add(5);
WriteLine(String.Join(", ", ListOfNumbers));

private IList<int> _listOfNumbers;
public IList<int> ListOfNumbers => _listOfNumbers ??= new List<int>();
