// IEnumerator
// ----------------------------------------------------------
// Supports a simple iteration over a non-generic collection.
// ----------------------------------------------------------

#load "entities.csx"

var course = new Course();

foreach (var item in course)
{
    WriteLine(item.ToString());
}
