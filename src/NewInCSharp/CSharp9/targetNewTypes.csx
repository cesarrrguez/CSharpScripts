public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString() => $"Name: {Name}, Age: {Age}";
}

var person = new Person { Name = "César", Age = 36 };
WriteLine(person);
