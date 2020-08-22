// Default date
Console.WriteLine($"Default date: {new DateTime()}\n");

// Now date
Console.WriteLine($"Now date: {DateTime.Now}\n");

// Specific date
Console.WriteLine($"Specific date: {new DateTime(2042, 12, 24)}\n");

// Date with time
Console.WriteLine($"Date with time: {new DateTime(2042, 12, 24, 18, 42, 0)}\n");

// Date without time
Console.WriteLine($"Date without time: {new DateTime(2042, 12, 24, 18, 42, 0).Date}\n");

// Short date String
Console.WriteLine($"Short date string: {DateTime.Now.ToShortDateString()}\n");

// Long date String
Console.WriteLine($"Long date string: {DateTime.Now.ToLongDateString()}\n");

// Specific region
var usCulture = new System.Globalization.CultureInfo("en-US");
Console.WriteLine($"Specific region: {DateTime.Now.ToString(usCulture.DateTimeFormat)}\n");

// Standard formats
DateTime dt = new DateTime(2042, 12, 24, 18, 42, 0);
Console.WriteLine("Standard formats");
Console.WriteLine($"Short date pattern (d): { dt.ToString("d") }");
Console.WriteLine($"Long date pattern (D): { dt.ToString("D") }");
Console.WriteLine($"Full date/time pattern (F): { dt.ToString("F") }");
Console.WriteLine($"Year/month pattern (y): { dt.ToString("y") }\n");

// Personal formats
Console.WriteLine("Personal formats");
Console.WriteLine(dt.ToString("MM'/'dd yyyy"));
Console.WriteLine(dt.ToString("dd.MM.yyyy"));
Console.WriteLine(dt.ToString("MM.dd.yyyy HH:mm"));
Console.WriteLine(dt.ToString("dddd, MMMM (yyyy): HH:mm:ss"));
Console.WriteLine(dt.ToString("dddd @ hh:mm tt\n", System.Globalization.CultureInfo.InvariantCulture));

// Building dates
var dateString = "7/6/2020";
DateTime userDate;
Console.WriteLine("Building dates");
if (DateTime.TryParse(dateString, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out userDate))
    Console.WriteLine("Valid date entered (long date format): " + userDate.ToLongDateString());
else
    Console.WriteLine("Invalid date specified!");
