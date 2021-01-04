public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age) => (Name, Age) = (name, age);
    public void Deconstruct(out string name, out int age) => (name, age) = (Name, Age);
}

// Type Patterns
object checkType = new int();
string GetType => checkType switch
{
    string => "string", // In C# 9 you can match against the type only  
    int => "int",
    _ => "obj"
};
WriteLine(GetType); // int

// Logical patterns
// Or patterns
var person = new Person("César", 36);
string AgeInRange => person switch
{
    Person(_, < 18) => "less than 18",
    (_, 18) or (_, > 18) => "18 or greater"
};
WriteLine(AgeInRange); // 18 or greater

// And patterns
string AgeInRange2 => person switch
{
    Person(_, < 18) => "less than 18",
    ("César", _) and (_, > 18) => "César is greater than 18",
    _ => throw new NotImplementedException()
};
WriteLine(AgeInRange2); // César is greater than 18

// Negated not patterns
string MeOrNot => person switch
{
    not ("César", 36) => "not me!",
    _ => "Me"
};
WriteLine(MeOrNot); // Me

// Parenthesized patterns
public record IsNumber(bool IsValid, int Number);
var is10 = new IsNumber(true, 10);
string N10 => is10 switch
{
    ((_, > 1 and < 5) and (_, > 5 and < 9)) or (_, 10) => "10",
    _ => "not 10"
};
WriteLine(N10); // 10

// Relational Patterns
string AgeInRange3 = person switch
{
    Person(_, < 18) => "less than 18", // The type Person is defined
    (_, > 18) => "greater than 18", // the type Person is inferred
    (_, 18) => "18 years old!"
};
WriteLine(AgeInRange3); // greater than 18
