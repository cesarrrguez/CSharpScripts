public record Person(string Name, int Age);

var family = new Person[]
{
    new("Jim", 15),
    new("John", 20),
    new("Jill", 25),
    new("Jack", 30),
};

WriteLine(family.Where(n => n.Age == 21).FirstOrDefault(new Person("Ghost", 21)));
// Person { Name = Ghost, Age = 21 }

WriteLine(family.Where(n => n.Age == 21).LastOrDefault(new Person("Ghost", 21)));
// Person { Name = Ghost, Age = 21 }

WriteLine(family.Where(n => n.Age == 21).SingleOrDefault(new Person("Ghost", 21)));
// Person { Name = Ghost, Age = 21 }
