string x = "Hello";
string y = "Hello";

if ((x == y) || (x != null && y != null && x.Equals(y)))
{
    WriteLine("Are Equals");
}

// Object.Equals method
if (Object.Equals(x, y))
{
    WriteLine("Are Equals");
}
