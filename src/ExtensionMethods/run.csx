#load "../../packages.csx"

#load "utils.csx"
#load "entities.csx"

var array1 = new double[10];
var array2 = new double[10];

array1.Populate(21);
array1.CopyTo(array2);
array1.Clear();

WriteLine("Populate, CopyTo and Clear:");
WriteLine($"Array 1: {string.Join(", ", array1)}");
WriteLine($"Array 2: {string.Join(", ", array2)}");

WriteLine("\nContains:");
WriteLine($"Array 1: {array1.Contains(21)}");
WriteLine($"Array 2: {array2.Contains(21)}");

WriteLine("\nSumSlow:");
WriteLine($"Array 1: {array1.SumSlow()}");
WriteLine($"Array 2: {array2.SumSlow()}");

WriteLine("\nSlice:");
WriteLine($"SubArray 1: {string.Join(", ", array1.Slice(0, 3))}");

// Set
WriteLine("\nSwap:");
array1[0] = 55;
WriteLine($"Array 1 before swap: {string.Join(", ", array1)}");
array1.Swap(0, 1);
WriteLine($"Array 1 after swap: {string.Join(", ", array1)}");

// Clone
var list1 = new List<string> { "Hello", "World", "Every", "Body", "From", "List 1" };
var list2 = list1.Clone();
list2.RemoveAt(list2.Count - 1);
list2.Add("List 2");
list2[0] = "Hi";

WriteLine("\nClone:");
WriteLine($"List 1: {string.Join(", ", list1)}");
WriteLine($"List 2: {string.Join(", ", list2)}");

// Clone with objects. Same reference
var list3 = new List<User> { new User("James"), new User("John") };
var list4 = list3.Clone();
list4.RemoveAt(list4.Count - 1);
list4.Add(new User("Olivia"));
list4[0].SetAge(21);

WriteLine("\nClone with objects:");
WriteLine($"List 3: {string.Join(", ", list3)}");
WriteLine($"List 4: {string.Join(", ", list4)}");

// Clone List
list3 = new List<User> { new User("James"), new User("John") };
list4 = list3.CloneList();
list4.RemoveAt(list4.Count - 1);
list4.Add(new User("Olivia"));
list4[0].SetAge(21);

WriteLine("\nClone List:");
WriteLine($"List 3: {string.Join(", ", list3)}");
WriteLine($"List 4: {string.Join(", ", list4)}");

// Deep Clone
var user1 = new User("James");
user1.SetAge(18);
var user2 = user1.DeepClone();
user2.SetAge(15);

WriteLine("\nDeep Clone:");
WriteLine($"User 1: {user1}");
WriteLine($"User 2: {user2}");

// Property List
WriteLine("\nPropertyList:");
WriteLine(user2.PropertyList());

// Bool to string
var display = true;
WriteLine($"Display bool: {display.ToYesNoString()}");
