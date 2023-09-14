#load "../../packages.csx"

#load "valueObjects.csx"

var temp1 = Celsius.From(20);
WriteLine(temp1);

//var temp2  = Celsius.From(-300); // Exception thrown

var temp3 = Celsius.From(100);
var temp4 = Celsius.From(20);

WriteLine(temp1 == temp3);
WriteLine(temp1 == temp4);
