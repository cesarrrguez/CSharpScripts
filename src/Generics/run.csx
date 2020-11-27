#load "entities.csx"
#load "utils.csx"

var company = new Company("This is a Company");
var person = new Person("This is a Person");

Person otherPerson;

TestGeneric(company);
TestGeneric(person);
TestGeneric(otherPerson);

// My list of companies
var companies = new MyList<Company>();
companies.AddItem(new Company("Google"));
companies.AddItem(new Company("Microsoft"));
WriteLine($"{companies.Counter} Items: {string.Join(", ", companies.Items)}");

// My list of people
var people = new MyList<Person>();
people.AddItem(new Person("James"));
people.AddItem(new Person("Kevin"));
people.AddItem(new Person("Olivia"));
WriteLine($"{people.Counter} Items: {string.Join(", ", people.Items)}");
