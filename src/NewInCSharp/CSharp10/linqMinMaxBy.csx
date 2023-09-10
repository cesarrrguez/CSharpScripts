public record Person(string Name, int Age);

var family = new Person[]
{
    new("Jim", 15),
    new("John", 20),
    new("Jill", 25),
    new("Jack", 30),
};

int minAge = family.Min(x => x.Age); // C# 9
int maxAge = family.Max(x => x.Age); // C# 9

Person youngestCSharp9 = family.OrderBy(x => x.Age).FirstOrDefault(); // C# 9
Person oldestCSharp9 = family.OrderByDescending(x => x.Age).FirstOrDefault(); // C# 9

Person youngestCSharp10 = family.MinBy(x => x.Age); // C# 10
Person oldestCSharp10 = family.MaxBy(x => x.Age); // C# 10
