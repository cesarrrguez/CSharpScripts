using System.Text.RegularExpressions;

var text = "The carpenter's car";
var exp = "";
MatchCollection founded;

// Method 1
exp = "car";
var expReg = new Regex(exp);
founded = expReg.Matches(text);
WriteLine($"Method 1: {string.Join(", ", founded)}");

// Method 2
exp = "car";
founded = Regex.Matches(text, exp);
WriteLine($"Method 2: {string.Join(", ", founded)}");

// IsMatch
exp = "car";
WriteLine($"IsMatch: {Regex.IsMatch(text, exp)}");

// Any character '.'
exp = "car.";
founded = Regex.Matches(text, exp);
WriteLine($"Any character '.': {string.Join(", ", founded)}");

// Character classes '[]'
exp = "[ht]e";
founded = Regex.Matches(text, exp);
WriteLine($"Character classes '[]': {string.Join(", ", founded)}");

// Ranges '[-]'
exp = "[a-i]e";
founded = Regex.Matches(text, exp);
WriteLine($"Ranges '[-]': {string.Join(", ", founded)}");

// Complement '^'
exp = "[^h]e";
founded = Regex.Matches(text, exp);
WriteLine($"Complement '^': {string.Join(", ", founded)}");

// Ends
exp = "car$";
founded = Regex.Matches(text, exp);
WriteLine($"Ends '$': {string.Join(", ", founded)}");

// Optional element
exp = "carp?";
founded = Regex.Matches(text, exp);
WriteLine($"Optional element '?': {string.Join(", ", founded)}");

// Quantificator
exp = "[a-c]{2}";
founded = Regex.Matches(text, exp);
WriteLine($"Quantificator '{{}}': {string.Join(", ", founded)}");

// Alternatives
text = "The carpenter's house";
exp = "(house|car)";
founded = Regex.Matches(text, exp);
WriteLine($"Alternatives '(|)': {string.Join(", ", founded)}");
text = "The carpenter's car";

// Split
exp = " ";
var words = Regex.Split(text, exp);
WriteLine($"Split: {string.Join(", ", words)}");

// Replace
exp = "car$";
expReg = new Regex(exp);
var replace = "tree";
var result = expReg.Replace(text, replace);
WriteLine($"Replace: {string.Join(", ", result)}");
