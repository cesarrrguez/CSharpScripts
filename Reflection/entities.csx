public class Company
{
    public int Id { get; set; }
    public string Description { get; set; }

    public override string ToString() => $"Company. Id: {Id}, Description: {Description}";
}

public class Person
{
    public int Id { get; set; }
    public string Description { get; set; }

    public override string ToString() => $"Person. Id: {Id}, Description: {Description}";
}
