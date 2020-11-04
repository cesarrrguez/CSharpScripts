#load "entities.csx"

var course = new Course();

Console.WriteLine("Student 1:");
var student1 = course[0];
Console.WriteLine(student1);

Console.WriteLine("\nStudent 2:");
var student2 = course[1];
Console.WriteLine(student2);

Console.WriteLine("\nAll students:");
for (var i = 0; i < 2; i++)
    Console.WriteLine(course[i]);
