public class User
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Empty constructor for CsvHelper
    public User() { }

    public User(string name, int age)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Age = age;
    }

    public override string ToString() => $"{Name} ({Age})";
}
