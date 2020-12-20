#load "entities.csx"

var course = new Course();

// Loop
foreach (var item in course)
{
    WriteLine(item.ToString());
}

WriteLine();

// Iterator
var iterator = course.GetEnumerator();

// While. Use of MoveNext and Current
while (iterator.MoveNext())
{
    WriteLine(iterator.Current);
}

WriteLine();

// Use of Reset
iterator.Reset();

// While. Use of MoveNext and Current
while (iterator.MoveNext())
{
    WriteLine(iterator.Current);
}
