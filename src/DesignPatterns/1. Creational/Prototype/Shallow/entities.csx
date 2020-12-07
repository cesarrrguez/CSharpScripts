// Product 1
public class User : ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }

    public User(string name, int age)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Age = age;
    }

    public object Clone() => MemberwiseClone();

    public override string ToString() => $"Name: {Name}, Age: {Age}";
}
