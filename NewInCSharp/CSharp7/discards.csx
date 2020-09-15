// Calling methods with out parameters
var input = "7";
if (int.TryParse(input, out _))
    WriteLine(input);
else
    WriteLine("Could not parse input");

// Deconstructing tuples
var person = new Person() { Name = "James", Company = "Microsoft" };
(string name, string company, _) = person;
WriteLine($"Person: {name}, {company}");

public class Person
{
    public string Name { get; set; }
    public string Company { get; set; }
    public string Country { get; set; }

    public void Deconstruct(out string name, out string company, out string country)
    {
        name = Name;
        company = Company;
        country = Country;
    }
}
