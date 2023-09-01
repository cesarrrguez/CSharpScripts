using ProtoBuf;

// Product 1
[Serializable, ProtoContract]
public class User
{
    [ProtoMember(1)]
    public string Name { get; set; }
    [ProtoMember(2)]
    public int Age { get; set; }
    [ProtoMember(3)]
    public Address Address { get; set; }

    // Empty constructor for ProtoBuf
    protected User() { }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString() => $"Name: {Name}, Age: {Age}";
}

// Product 2
[Serializable, ProtoContract]
public class Address
{
    [ProtoMember(1)]
    public string Street { get; set; }
    [ProtoMember(2)]
    public string City { get; set; }

    // Empty constructor for ProtoBuf
    protected Address() { }

    public Address(string street, string city)
    {
        Street = street;
        City = city;
    }

    public override string ToString() => $"Street: {Street}, City: {City}";
}
