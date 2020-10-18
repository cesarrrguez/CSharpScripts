// IEquatable
// -----------------------------------------------------------------------
// Defines a generalized method that a value type or class implements 
// to create a type-specific method for determining equality of instances.
// -----------------------------------------------------------------------

#load "entities.csx"

var listOfObjects = new List<MyObject>();

listOfObjects.Add(new MyObject { Property1 = 1, Property2 = 1, Property3 = 1 });
listOfObjects.Add(new MyObject { Property1 = 1, Property2 = 2, Property3 = 3 });
listOfObjects.Add(new MyObject { Property1 = 1, Property2 = 1, Property3 = 1 });

foreach (var item in listOfObjects.Distinct())
{
    Console.WriteLine(item);
}
