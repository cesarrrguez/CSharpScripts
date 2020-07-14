public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Address Address { get; private set; }

    public User(string firstName, string lastName)
    {
        Id = new Guid();
        FirstName = firstName;
        LastName = lastName;
    }

    public void AddAddress(string street, string city)
    {
        Address = new Address(street, city);
    }

    public override string ToString()
    {
        var result = $"User. Id: {Id}, FirstName: {FirstName}, LastName: {LastName}";

        if (Address != null)
            result += $"\n\t{Address}";

        return result;
    }
}

public class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }

    public Address(string street, string city)
    {
        Street = street;
        City = city;
    }

    public override string ToString()
    {
        return $"Address. Street: {Street}, City: {City}";
    }
}

public class UserDTO
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }

    public override string ToString()
    {
        return $"User. Id: {Id}, Name: {Name}, Street: {Street}, City: {City}";
    }
}
