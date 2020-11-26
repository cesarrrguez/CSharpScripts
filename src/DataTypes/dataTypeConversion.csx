int number = 0;
decimal money = 9500.34m;

number = (int)money; // An explicit conversion using cast operator.
WriteLine(number);

// Using the Convert class which supports full Data Type conversion between all data types is the best option.
string userValue = "77";
money = Convert.ToInt32(userValue);
WriteLine(money);
