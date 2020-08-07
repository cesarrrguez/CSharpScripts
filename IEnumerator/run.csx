
#load "entities.csx"

var course = new Course();

foreach (var item in course)
{
    Console.WriteLine(item.ToString());
}
