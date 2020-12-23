public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal AccountBalance { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<Address> Addresses { get; set; }
}

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
}
