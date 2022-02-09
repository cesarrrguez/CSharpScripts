int i = 0;
uint ui = 0;
decimal x = 0.0m;
float f = 0.0f;
double d = 0.0D;
string hello = "Hello world";
bool flag = false;
DateTime date = DateTime.MinValue;

WriteLine("The value of i is: {0}", i);
WriteLine("The value of ui is: {0}", ui);
WriteLine("The value of x is: {0:C}", x);
WriteLine("The value of f is: {0:F2}", f);
WriteLine("The value of d is: {0:F2}", d);
WriteLine("The value of hello is: " + hello);
WriteLine("The value of flag is: " + flag.ToString());
WriteLine("The value of date is: {0}", date.ToShortDateString());
