#load "entities.csx"

var listOfObjects = new List<MyObject>
    {
        new MyObject{Property="4CB8901"},
        new MyObject{Property="4CJ4601"},
        new MyObject{Property="4EN0001"},
        new MyObject{Property="4EZ7601"},
    };

foreach (var item in listOfObjects)
{
    WriteLine(listOfObjects.IndexOf(item));
}
