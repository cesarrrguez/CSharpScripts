#load "valueObject.csx"

public class Address : ValueObject
{
    public string Street { get; init; }
    public string ZipCode { get; init; }
    public string City { get; init; }

    public Address(string street, string zipCode, string city)
    {
        Street = street;
        ZipCode = zipCode;
        City = city;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return ZipCode;
        yield return City;
    }
}
