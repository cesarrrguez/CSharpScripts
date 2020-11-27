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
WriteLine(string.Join(", ", ListOfNumbers));

private IList<int> _listOfNumbers;
public IList<int> ListOfNumbers => _listOfNumbers ??= new List<int>();
