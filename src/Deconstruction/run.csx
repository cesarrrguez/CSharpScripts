#load "entities.csx"

// Deconstructing a person
var person = new Person
{
    FullName = "John Doe",
    DateOfBirth = new DateOnly(1990, 1, 21)
};

var (fullName, dateOfBirth) = person;
WriteLine($"The name is: {fullName}, born in {dateOfBirth}");

// Deconstructing a dictionary
var dictionary = new Dictionary<string, int>
{
    {"John Doe", 121},
};

var (key, value) = dictionary.First();
WriteLine($"The key is: {key}, value is: {value}");

// Deconstructing a tuple
(string name, int age) GetPersonDetails() => ("John Doe", 21);

var (name, age) = GetPersonDetails();
WriteLine($"The name is: {name}, age is: {age}");

// Deconstructing a record
public record Book(string Title, string Author);

var (title, author) = new Book("The C# Language", "Joe Smith");
WriteLine($"The title is: {title}, author is: {author}");
