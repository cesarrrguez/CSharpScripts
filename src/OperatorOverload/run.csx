#load "entities.csx"

// Object. Operator == and !=
var object1 = new MyObject { Property1 = 1, Property2 = 2, Property3 = 3 };
var object2 = new MyObject { Property1 = 1, Property2 = 2, Property3 = 3 };

var result = object1 == object2;
WriteLine(result);

// List. Operator +
var list1 = new MyList<string>() { "Apple", "Orange" };
var list2 = new MyList<string>() { "Banana", "Pineapple" };
var list = list1 + list2;
WriteLine(string.Join(", ", list));
