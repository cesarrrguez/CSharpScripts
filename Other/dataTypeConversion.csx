// Explicit conversions require a cast operator. 
// In addition, the destination and source variables should be compatible
// Conversion with the assistance of a helper class such as Convert enables us 
// to convert between non-compatible types. This does not need the use of a cast operator.  

int number = 0;
decimal money = 9500.34m;

number = (int)money; // An explicit conversion using cast operator.
Console.WriteLine(number);

// Using the Convert class which supports full Data Type conversion between all data types is the best option.
string userValue = "77";
money = Convert.ToInt32(userValue);
Console.WriteLine(money);
