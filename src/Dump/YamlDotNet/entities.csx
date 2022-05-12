public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Dictionary<string, Address> Addresses { get; set; }
}

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
}
