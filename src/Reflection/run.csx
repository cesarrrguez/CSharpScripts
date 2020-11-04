#load "entities.csx"

var type = Type.GetType("System.Collections.ArrayList");

Console.WriteLine($"Base class: {type.BaseType}");
Console.WriteLine($"Class: {type.IsClass}");
Console.WriteLine($"Abstract: {type.IsAbstract}");
Console.WriteLine($"Sealed: {type.IsSealed}");
Console.WriteLine($"Generic: {type.IsGenericTypeDefinition}");
Console.WriteLine($"\nFields: {String.Join(", ", type.GetFields().ToList())}");
Console.WriteLine($"\nProperties: {String.Join(", ", type.GetProperties().ToList())}");
Console.WriteLine($"\nMethods: {String.Join(", ", type.GetMethods().ToList())}");
Console.WriteLine($"\nInterfaces: {String.Join(", ", type.GetInterfaces().ToList())}");

// Company properties to Person properties
Console.WriteLine("\nCompany properties to Person properties:");

var company = new Company
{
    Id = 100,
    Description = "This is the description"
};
var person = new Person();

foreach (var property in company.GetType().GetProperties())
{
    var propertyInfo = person.GetType().GetProperty(property.Name);

    propertyInfo?.SetValue(person, property.GetValue(company));
}

Console.WriteLine(company);
Console.WriteLine(person);
