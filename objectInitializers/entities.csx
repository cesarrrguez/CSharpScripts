public class Child
{
    public int Age { get; set; }
    public string Name { get; set; }
    public string StreetAddress { get; set; }

    public override string ToString()
    {
        return $"Child. Age: {Age}, Name: {Name}, StreetAddress: {StreetAddress}";
    }
}
