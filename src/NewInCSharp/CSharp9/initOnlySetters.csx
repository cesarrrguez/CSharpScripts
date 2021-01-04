public class Person
{
    public string Name { get; init; }
    public int Age { get; init; }

    public override string ToString() => $"Name: {Name}, Age: {Age}";
}

var person = new Person { Name = "César", Age = 36 };
WriteLine(person);

// person.Age = 40; // Error
// error CS8852: Init-only property or indexer 'Person.Age' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor.
