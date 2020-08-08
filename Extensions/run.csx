#load "utils.csx"
#load "entities.csx"

var array1 = new double[10];
var array2 = new double[10];

array1.Populate(21);
array1.CopyTo(array2);
array1.Clear();

Console.WriteLine("Populate, CopyTo and Clear:");
Console.WriteLine($"Array 1: {string.Join(", ", array1)}");
Console.WriteLine($"Array 2: {string.Join(", ", array2)}");

Console.WriteLine("\nContains:");
Console.WriteLine($"Array 1: {array1.Contains(21)}");
Console.WriteLine($"Array 2: {array2.Contains(21)}");

Console.WriteLine("\nSumSlow:");
Console.WriteLine($"Array 1: {array1.SumSlow()}");
Console.WriteLine($"Array 2: {array2.SumSlow()}");

Console.WriteLine("\nSlice:");
Console.WriteLine($"SubArray 1: {string.Join(", ", array1.Slice(0, 3))}");

// Clone
var list1 = new List<string> { "Hello", "World", "Every", "Body", "From", "List 1" };
var list2 = list1.Clone();
list2.RemoveAt(list2.Count - 1);
list2.Add("List 2");

Console.WriteLine("\nClone:");
Console.WriteLine($"List 1: {string.Join(", ", list1)}");
Console.WriteLine($"List 2: {string.Join(", ", list2)}");

// Deep Clone
var user1 = new User("James");
user1.SetAge(18);
var user2 = user1.DeepClone();
user2.SetAge(15);

Console.WriteLine("\nDeep Clone:");
Console.WriteLine($"User 1: {user1}");
Console.WriteLine($"User 2: {user2}");

// Property List
Console.WriteLine("\nPropertyList:");
Console.WriteLine(user2.PropertyList());
