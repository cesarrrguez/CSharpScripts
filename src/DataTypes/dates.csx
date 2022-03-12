
using System.Globalization;

// Default date
WriteLine($"Default date: {new DateTime()}\n");

// Now date
WriteLine($"Now date: {DateTime.Now}\n");

// Specific date
WriteLine($"Specific date: {new DateTime(2042, 12, 24)}\n");

// Date with time
WriteLine($"Date with time: {new DateTime(2042, 12, 24, 18, 42, 0)}\n");

// Date without time
WriteLine($"Date without time: {new DateTime(2042, 12, 24, 18, 42, 0).Date}\n");

// Short date String
WriteLine($"Short date string: {DateTime.Now.ToShortDateString()}\n");

// Long date String
WriteLine($"Long date string: {DateTime.Now.ToLongDateString()}\n");

// Specific region
var usCulture = new CultureInfo("en-US");
WriteLine($"Specific region: {DateTime.Now.ToString(usCulture.DateTimeFormat)}\n");

// Standard formats
DateTime dt = new DateTime(2042, 12, 24, 18, 42, 0);
WriteLine("Standard formats");
WriteLine($"Short date pattern (d): { dt.ToString("d") }");
WriteLine($"Long date pattern (D): { dt.ToString("D") }");
WriteLine($"Full date/time pattern (F): { dt.ToString("F") }");
WriteLine($"Year/month pattern (y): { dt.ToString("y") }\n");

// Personal formats
WriteLine("Personal formats");
WriteLine(dt.ToString("MM'/'dd yyyy"));
WriteLine(dt.ToString("dd.MM.yyyy"));
WriteLine(dt.ToString("MM.dd.yyyy HH:mm"));
WriteLine(dt.ToString("dddd, MMMM (yyyy): HH:mm:ss"));
WriteLine(dt.ToString("dddd @ hh:mm tt\n", CultureInfo.InvariantCulture));

// Building dates
var dateString = "7/6/2020";
DateTime userDate;
WriteLine("Building dates");
if (DateTime.TryParse(dateString, usCulture.DateTimeFormat, DateTimeStyles.None, out userDate))
{
    WriteLine("Valid date entered (long date format): " + userDate.ToLongDateString());
}
else
{
    WriteLine("Invalid date specified!");
}

// Parse exact
WriteLine("\nParse exact");
var date1 = DateTime.ParseExact("01-12-2021", "dd-MM-yyyy", CultureInfo.InvariantCulture);
var date2 = DateTime.ParseExact("01-12-2021", "MM-dd-yyyy", CultureInfo.InvariantCulture);

WriteLine($"{date1.Day}-{date1.Month}-{date1.Year}");
WriteLine($"{date2.Day}-{date2.Month}-{date2.Year}");
