#load "entities.csx"
#load "utils.csx"

Company company = new Company
{
    Description = "This is a Company"
};

Person person = new Person
{
    Description = "This is a Person"
};

Person otherPerson = null;

TestGeneric(company);
TestGeneric(person);
TestGeneric(otherPerson);
