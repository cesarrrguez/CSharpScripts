var names = new[] { "James Bond", "John Doe", "Marie Curie" };
var ages = new[] { 32, 33, 34 };
var favoriteColors = new[] { "red", "blue", "green" };

// Zip combine two sequences into one sequence of pairs
IEnumerable<(string, int, string)> zip = names.Zip(ages, favoriteColors);

foreach (var (Name, Age, Color) in zip)
{
    WriteLine($"{Name} is {Age} years old and his favorite color is {Color}");
}

// James Bond is 32 years old and his favorite color is red
// John Doe is 33 years old and his favorite color is blue
// Marie Curie is 34 years old and his favorite color is green
