var names = new[] { "John", "Paul", "George", "Ringo" };

var name = names[3]; // C# 9. [3] is same as .ElementAt(3)
var thirdItemFromTheEnd = names.ElementAt(^3); // C# 10

WriteLine(name); // Ringo
WriteLine(thirdItemFromTheEnd); // Paul
