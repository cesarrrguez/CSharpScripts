public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; }
    public string LastName { get; }
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
    public string Street { get; }
    public string City { get; }

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
