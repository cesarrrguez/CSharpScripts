// Product 1
public class User : ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Address Address { get; set; }

    public User(string name, int age)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Age = age;
    }

    public object Clone()
    {
        var user = MemberwiseClone() as User;
        user.Address = new Address(user.Address.Street, user.Address.City);

        return user;
    }

    public override string ToString() => $"Name: {Name}, Age: {Age}";
}

// Product 2
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
