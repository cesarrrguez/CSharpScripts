#load "util.csx"

// Create 4 Person objects
Person person1 = new Person() { Name = "John", Age = 41 };
Person person2 = new Person() { Name = "Jane", Age = 69 };
Person person3 = new Person() { Name = "Jake", Age = 12 };
Person person4 = new Person() { Name = "Jessie", Age = 25 };

// Create a list of Person objects and fill it
List<Person> people = new List<Person>() { person1, person2, person3, person4 };

// Invoke DisplayPeople using appropriate delegate
PersonUtil.DisplayPeople("Children:", people, PersonUtil.IsChild);
PersonUtil.DisplayPeople("Adults:", people, PersonUtil.IsAdult);
PersonUtil.DisplayPeople("Seniors:", people, PersonUtil.IsSenior);
