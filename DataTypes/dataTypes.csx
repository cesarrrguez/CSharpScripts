int i = 0;
uint ui = 0;
decimal x = 0.0m;
float f = 0.0f;
double d = 0.0D;
string hello = "Hello world";
bool flag = false;
DateTime date = DateTime.MinValue;

Console.WriteLine("The value of i is: {0}", i);
Console.WriteLine("The value of ui is: {0}", ui);
Console.WriteLine("The value of x is: {0:C}", x);
Console.WriteLine("The value of f is: {0:F2}", f);
Console.WriteLine("The value of d is: {0:F2}", d);
Console.WriteLine("The value of hello is: " + hello);
Console.WriteLine("The value of flag is: " + flag.ToString());
Console.WriteLine("The value of date is: {0}", date.ToShortDateString());

