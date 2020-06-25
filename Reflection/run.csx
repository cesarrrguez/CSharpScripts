#load "entities.csx"

var company = new Company
{
    Id = 100,
    Description = "This is the description"
};

var person = new Person();

var companyProperties = company.GetType().GetProperties();

foreach (var property in companyProperties)
{
    var propertyInfo = person.GetType().GetProperty(property.Name);

    if (propertyInfo != null)
    {
        propertyInfo.SetValue(person, property.GetValue(company));
    }
}

Console.WriteLine(company);
Console.WriteLine();
Console.WriteLine(person);
