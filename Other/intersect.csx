var list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var list2 = new List<int> { 3, 9 };

var list3 = list1.Intersect(list2);

Console.WriteLine(String.Join(", ", list3));
