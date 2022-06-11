public record User(string Name, int Age);

User user = new("César", 21);
WriteLine($"Name: {user.Name}"); // Name: César

// Override
public record UserString(string Name, int Age)
{
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}

UserString userString = new("César", 21);
WriteLine(userString); // Name: César, Age: 21

// Sealed Override
public record UserStringSealed(string Name, int Age)
{
    public sealed override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}

public record Dummy : UserStringSealed
{
    public Dummy(string name, int age) : base(name, age) { }

    // public override string ToString() // Error
    // {
    //     return $"Name: {Name}, subject A: {Results.SubjectA}";
    // }
}
