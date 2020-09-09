#load "entities.csx"

[Obsolete]
var test = new Test();

var test2 = new Test2();

var type = typeof(Test2);
var customAttributes = type.GetCustomAttributes(false);

foreach (DataAttribute item in customAttributes)
    Console.WriteLine("{0}", item.Data);
