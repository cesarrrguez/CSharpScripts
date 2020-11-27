#load "entities.csx"

var course = new Course();

WriteLine("Student 1:");
var student1 = course[0];
WriteLine(student1);

WriteLine("\nStudent 2:");
var student2 = course[1];
WriteLine(student2);

WriteLine("\nAll students:");
for (var i = 0; i < 2; i++)
{
    WriteLine(course[i]);
}
