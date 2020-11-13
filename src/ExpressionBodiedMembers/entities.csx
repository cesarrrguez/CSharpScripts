public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    private readonly string[] emails = new string[10];

    // Read-only property. C# 6.0
    public string Name => FirstName + " " + LastName;

    // Property. C# 7.0
    private int _age;
    public int Age
    {
        get => _age;
        set => _age = value * 10;
    }

    // Constructor. C# 7.0
    public User(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);
    public User(int age) => Age = age;

    // Destructor. C# 7.0
    ~User() => WriteLine($"The {GetType().Name} destructor is executing");

    // Method. C# 6.0
    public override string ToString() => $"User. Name: {Name}, Age: {Age}, Emails: {String.Join(", ", emails.Where(x => !String.IsNullOrWhiteSpace(x)))}";

    // Indexer. C# 7.0
    public string this[int i]
    {
        get => emails[i];
        set => emails[i] = value;
    }
}
