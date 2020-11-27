string x = "Hello";
string y = "Hello";

if ((x == y) || (x != null && y != null && x.Equals(y)))
{
    WriteLine("Are Equals");
}

// Object.Equals method
if (Equals(x, y))
{
    WriteLine("Are Equals");
}
