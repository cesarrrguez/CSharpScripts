// Product 1
[Serializable]
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Address Address { get; set; }

    public User(string name, int age)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Age = age;
    }

    public override string ToString() => $"Name: {Name}, Age: {Age}";
}

// Product 2
[Serializable]
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }

    public Address(string street, string city)
    {
        Street = street ?? throw new ArgumentNullException(nameof(street));
        City = city ?? throw new ArgumentNullException(nameof(city));
    }

    public override string ToString() => $"Street: {Street}, City: {City}";
}
