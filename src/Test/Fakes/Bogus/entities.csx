public class Order
{
    public Guid Id { get; set; }
    public string Currency { get; set; }
    public decimal Price { get; set; }
    public bool IsPaid { get; set; }
    public BillingDetails BillingDetails { get; set; }
}

public class BillingDetails
{
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public List<string> Phones { get; set; }
    public string AddressLine { get; set; }
    public string PostCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}
