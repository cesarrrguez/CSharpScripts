public class Person
{
    public string Name { get; set; }

    public override string ToString() => $"Person has name {Name}";
}
