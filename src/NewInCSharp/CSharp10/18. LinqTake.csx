var values = Enumerable.Range(0, 1000);

var resultCSharp9 = values.Skip(10).Take(15); // C# 9
var resultCSharp10 = values.Take(10..25); // C# 10

var lastThree = values.Take(^3..);
