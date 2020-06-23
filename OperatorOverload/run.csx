#load "entities.csx"

var object1 = new MyObject { Property1 = 1, Property2 = 2, Property3 = 3 };
var object2 = new MyObject { Property1 = 1, Property2 = 2, Property3 = 3 };

var result = object1 == object2;
Console.WriteLine(result);
