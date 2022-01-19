// By default, primitive types are passed by value
var text = "Unmodified text";
ChangeTextByValue(text);
WriteLine(text);

ChangeTextByRef(ref text);
WriteLine(text);

// By default, objects are passed by reference
var person = new Person { Name = "James" };
SetName(person, "Michael");
WriteLine(person);

public void ChangeTextByValue(string text) => text = "Text has changed";
public void ChangeTextByRef(ref string text) => text = "Text has changed";
public void SetName(Person person, string name) => person.Name = name;

public class Person
{
    public string Name { get; set; }

    public override string ToString() => $"Person has name {Name}";
}
