#load "entities.csx"

// Users
var users = new User[] {
    new User(1, "James Smith", 3),
    new User(2, "John Smith", 2),
    new User(3, "Olivia Johnson", 1),
    new User(4, "Michael Jones", 4)
};

// Courses
var courses = new Course[] {
    new Course(1, "UML"),
    new Course(2, "POO"),
    new Course(3, "Software Architecture"),
    new Course(4, "Design Patterns")
};

Console.WriteLine($"User array: {string.Join(", ", users.ToList())}");
Console.WriteLine($"Course array: {string.Join(", ", courses.ToList())}");
Console.WriteLine(new string(Enumerable.Repeat('-', 67).ToArray()));

// Object list
var objectList = users.Where(u => u.FullName.Contains("J")).OrderByDescending(u => u.Id).FirstOrDefault();
Console.WriteLine($"Object list: {string.Join(", ", objectList)}");

// Stars with
var starsWith = users.Where(u => u.FullName.StartsWith("J")).ToList();
Console.WriteLine($"Stars With J: {string.Join(", ", starsWith)}");

// Ends with
var endsWith = users.Where(u => u.FullName.EndsWith("n")).ToList();
Console.WriteLine($"Ends With n: {string.Join(", ", endsWith)}");

// Select
var select = users.Select(u => u.FullName.Split()).ToList();
Console.WriteLine($"Select: {string.Join(", ", select)}");

// Select many
var selectMany = users.SelectMany(u => u.FullName.Split()).ToList();
Console.WriteLine($"Select Many: {string.Join(", ", selectMany)}");

// Multiple variables
var multipleVariables = (from x in users where x.Id == 1 from y in x.FullName select x.FullName + " ==> " + y).ToList();
Console.WriteLine($"Multiple variables: {string.Join(", ", multipleVariables)}");

// Join
var join = (from u in users
            join c in courses on u.CourseId equals c.Id
            select u.FullName + " is on " + c.Title + " course").ToList();
Console.WriteLine($"Join: {string.Join(", ", join)}");

// Group join
var groupJoin = from u in users
                join c in courses on u.CourseId equals c.Id
                into tempList
                select new { User = u.FullName, tempList };
Console.WriteLine("Group join:");
foreach (var item in groupJoin)
    Console.WriteLine($"\tUser: {item.User}, Curses: {string.Join(", ", item.tempList)}");

// Zip
var zip = users.Zip(courses, (u, c) => u + " => " + c).ToList();
Console.WriteLine($"Zip: {string.Join(", ", zip)}");

// Order by + Then by
var orderByThenBy = users.OrderBy(u => u.FullName.Length).ThenBy(u => u).ToList();
Console.WriteLine($"Order by + Then by: {string.Join(", ", orderByThenBy)}");

// Group by
var groupBy = users.GroupBy(u => u.FullName.Split(" ")[1]).ToList();
Console.WriteLine("Group by:");
foreach (var item in groupBy)
    Console.WriteLine($"\tLastName: {item.Key}, Users: {string.Join(", ", item)}");
