#load "valueObjects.csx"

#r "nuget: ValueOf, 1.0.17"

var temp1  = Celsius.From(20);
WriteLine(temp1);

//var temp2  = Celsius.From(-300); // Exception throwed

var temp3 = Celsius.From(100);
var temp4 = Celsius.From(20);

WriteLine(temp1 == temp3);
WriteLine(temp1 == temp4);
