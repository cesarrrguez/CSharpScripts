#load "entities.csx"

// By default, primitive types are passed by value
var text = "Unmodified text";
ChangeTextByValue(text);
Console.WriteLine(text);

ChangeTextByRef(ref text);
Console.WriteLine(text);

// By default, objects are passed by reference
var person = new Person { Name = "James" };
SetName(person, "Michael");
Console.WriteLine(person);

public static void ChangeTextByValue(string text)
{
    text = "Text has changed";
}

public static void ChangeTextByRef(ref string text)
{
    text = "Text has changed";
}

public static void SetName(Person person, string name)
{
    person.Name = name;
}
