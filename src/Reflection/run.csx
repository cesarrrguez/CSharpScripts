#load "entities.csx"

var type = Type.GetType("System.Collections.ArrayList");

WriteLine($"Base class: {type.BaseType}");
WriteLine($"Class: {type.IsClass}");
WriteLine($"Abstract: {type.IsAbstract}");
WriteLine($"Sealed: {type.IsSealed}");
WriteLine($"Generic: {type.IsGenericTypeDefinition}");
WriteLine($"\nFields: {string.Join(", ", type.GetFields().ToList())}");
WriteLine($"\nProperties: {string.Join(", ", type.GetProperties().ToList())}");
WriteLine($"\nMethods: {string.Join(", ", type.GetMethods().ToList())}");
WriteLine($"\nInterfaces: {string.Join(", ", type.GetInterfaces().ToList())}");

// Company properties to Person properties
WriteLine("\nCompany properties to Person properties:");

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

WriteLine(company);
WriteLine(person);
