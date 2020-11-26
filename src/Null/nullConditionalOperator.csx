Person person = new Person
{
    Name = "Joe",
    Shoes = null
};

int? numberOfShoes = person.Shoes?.Count ?? 0;
WriteLine(numberOfShoes);

public class Person
{
    public string Name { get; set; }
    public List<int> Shoes { get; set; }
}
