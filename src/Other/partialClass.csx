var customer = new Customer { Name = "James", Age = 21 };
WriteLine(customer.GetInfo()); // James is 21 years old

public partial class Customer
{
    public string Name { get; set; }
}

public partial class Customer
{
    public int Age { get; set; }
    public string GetInfo() => $"{Name} is {Age} years old";
}
