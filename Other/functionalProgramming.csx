// Functional programming
// -----------------------------------------------------------------
// Functional methods that comes with the C# for manipulating lists.
// -----------------------------------------------------------------

// ForEach
WriteLine("ForEach:");
var numbers = new List<int>() { 1, 2, 3 };
numbers.ForEach(x => WriteLine(x));

// Where
WriteLine("\nWhere:");
numbers.Add(4);
numbers.Add(5);
var filteredNumbers = numbers.Where(x => x > 3).ToList();
filteredNumbers.ForEach(x => WriteLine(x));

// Find
WriteLine("\nFind:");
var words = new List<string>() { "Kevin", "James", "Olivia" };
var education = words.Find(x => x.Contains("ames"));
WriteLine(education);

// Exists
WriteLine("\nExists:");
var result = words.Exists(x => x.Contains("ames"));
Console.WriteLine(result);
