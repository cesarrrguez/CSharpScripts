using System.Text.RegularExpressions;

string text = "The carpenter's car";
string exp = "";
MatchCollection founded;

// Method 1
exp = "car";
var expReg = new Regex(exp);
founded = expReg.Matches(text);
Console.WriteLine($"Method 1: {string.Join(", ", founded)}");

// Method 2
exp = "car";
founded = Regex.Matches(text, exp);
Console.WriteLine($"Method 2: {string.Join(", ", founded)}");

// IsMatch
exp = "car";
Console.WriteLine($"IsMatch: {Regex.IsMatch(text, exp)}");

// Any character '.'
exp = "car.";
founded = Regex.Matches(text, exp);
Console.WriteLine($"Any character '.': {string.Join(", ", founded)}");

// Character classes '[]'
exp = "[ht]e";
founded = Regex.Matches(text, exp);
Console.WriteLine($"Character classes '[]': {string.Join(", ", founded)}");

// Ranges '[-]'
exp = "[a-i]e";
founded = Regex.Matches(text, exp);
Console.WriteLine($"Ranges '[-]': {string.Join(", ", founded)}");

// Complement '^'
exp = "[^h]e";
founded = Regex.Matches(text, exp);
Console.WriteLine($"Complement '^': {string.Join(", ", founded)}");

// Ends
exp = "car$";
founded = Regex.Matches(text, exp);
Console.WriteLine($"Ends '$': {string.Join(", ", founded)}");

// Optional element
exp = "carp?";
founded = Regex.Matches(text, exp);
Console.WriteLine($"Optional element '?': {string.Join(", ", founded)}");

// Quantificator
exp = "[a-c]{2}";
founded = Regex.Matches(text, exp);
Console.WriteLine($"Quantificator '{{}}': {string.Join(", ", founded)}");

// Alternatives
text = "The carpenter's house";
exp = "(house|car)";
founded = Regex.Matches(text, exp);
Console.WriteLine($"Alternatives '(|)': {string.Join(", ", founded)}");
text = "The carpenter's car";

// Split
exp = " ";
var words = Regex.Split(text, exp);
Console.WriteLine($"Split: {string.Join(", ", words)}");

// Replace
exp = "car$";
expReg = new Regex(exp);
string replace = "tree";
string result = expReg.Replace(text, replace);
Console.WriteLine($"Replace: {string.Join(", ", result)}");
