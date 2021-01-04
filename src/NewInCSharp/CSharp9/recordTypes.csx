// Default Record
public record Person(string Name, int Age);

var person1 = new Person("César", 36);
WriteLine(person1);

// Inheritance
public record Student(string Name, int Age, double Average) : Person(Name, Age);

var student = new Student("James", 17, 8);
WriteLine(student);

// Methods
public record Teacher(string Name, int Age, int From) : Person(Name, Age)
{
    public override string ToString()
    {
        return $"{Name} was born on {DateTime.Now.Year - Age} and is teacher from {From}";
    }
}

var teacher = new Teacher("John", 52, 2002);
WriteLine(teacher);

// Inmutable
// person1.Age = 40; // Error
// Error CS8852: Init-only property or indexer 'Person.Age' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor.

// Mutable Record
public record User
{
    public string Name { get; set; }
    public int Age { get; set; }
}

var user = new User { Name = "César", Age = 30 };
WriteLine(user);

user.Age = 40; // Change the mutable record
WriteLine(user);

// Equality
var person2 = new Person("César", 36);
WriteLine($"\nPerson2: {person2}");

WriteLine($"person1 == person2: {person1 == person2}"); // True. Structural equality   
WriteLine($"person1.Equals(person2): {person1.Equals(person2)}"); // True. Structural equality   
WriteLine($"object.ReferenceEquals(person1, person2): {ReferenceEquals(person1, person2)}"); // False. Referential equality 

// With keyword
var person3 = person1 with { Age = 40 }; // Change the default record
WriteLine($"\nPerson3: { person3}");

WriteLine($"person1 == person3: {person1 == person3}"); // False. Structural equality   
WriteLine($"person1.Equals(person3): {person1.Equals(person3)}"); // False. Structural equality   
WriteLine($"object.ReferenceEquals(person1, person3): {ReferenceEquals(person1, person3)}"); // False. Referential equality 

// Deconstruction the default record
var (name, age) = person1;
WriteLine($"\n{name} {age}");
