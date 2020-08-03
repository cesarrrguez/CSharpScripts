// The null conditional is a form of a member access operator. With a null conditional operator, 
// the expression A?.B evaluates to B if the left operand (A) is non-null; 
// otherwise, it evaluates to null.

Person person = new Person
{
    Name = "Joe",
    Shoes = null
};

int? numberOfShoes = person.Shoes?.Count ?? 0;
Console.WriteLine(numberOfShoes);

public class Person
{
    public string Name { get; set; }
    public List<int> Shoes { get; set; }
}
