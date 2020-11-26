#load "entities.csx"

var listOfObjects = new List<MyObject>();

listOfObjects.Add(new MyObject { Property1 = 1, Property2 = 1, Property3 = 1 });
listOfObjects.Add(new MyObject { Property1 = 1, Property2 = 2, Property3 = 3 });
listOfObjects.Add(new MyObject { Property1 = 1, Property2 = 1, Property3 = 1 });

foreach (var item in listOfObjects.Distinct())
{
    WriteLine(item);
}
