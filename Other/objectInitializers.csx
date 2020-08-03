Child child_1 = new Child();
child_1.Age = 10;
child_1.Name = "Bryan";
child_1.StreetAddress = "Seattle, WA 98124";
Console.WriteLine(child_1);

Child child_2 = new Child() { Age = 10, Name = "Bryan", StreetAddress = "Seattle, WA 98124" };
Console.WriteLine(child_2);


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
