#load "utils.csx"

// Create 4 Person objects
var person1 = new Person() { Name = "John", Age = 41 };
var person2 = new Person() { Name = "Jane", Age = 69 };
var person3 = new Person() { Name = "Jake", Age = 12 };
var person4 = new Person() { Name = "Jessie", Age = 25 };

// Create a list of Person objects and fill it
var people = new List<Person>() { person1, person2, person3, person4 };

// Invoke DisplayPeople using appropriate delegate
PersonUtil.DisplayPeople("Children:", people, PersonUtil.IsChild);
PersonUtil.DisplayPeople("Adults:", people, PersonUtil.IsAdult);
PersonUtil.DisplayPeople("Seniors:", people, PersonUtil.IsSenior);

// Delegate questions
PersonUtil.FilterDelegate filterDelegate = null;

// Is person 1 a child?
filterDelegate = new PersonUtil.FilterDelegate(PersonUtil.IsChild);
WriteLine($"Is person 1 a child? {filterDelegate(person1).ToYesNoString()}");

// Is person 4 an adult?
filterDelegate = new PersonUtil.FilterDelegate(PersonUtil.IsAdult);
WriteLine($"Is person 4 an adult? {filterDelegate(person4).ToYesNoString()}");

// Is person 2 a senior?
filterDelegate = new PersonUtil.FilterDelegate(PersonUtil.IsSenior);
WriteLine($"Is person 2 a senior? {filterDelegate(person2).ToYesNoString()}");
