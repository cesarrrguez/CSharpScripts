using System.Globalization;

string number = "3333,38748378438";

// Bad
var result1 = float.Parse(number, CultureInfo.InvariantCulture);
Console.WriteLine(result1);

// Good
var result2 = float.Parse(number.ToString(CultureInfo.InvariantCulture));
Console.WriteLine(result2);
