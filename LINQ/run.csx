#load "entities.csx"

// Int array
var intArray = new int[] { 1, 2, 10, 3, 2, 55, 666, 18, 2, 100, 2, 41 };

// List 1. LINQ (using query syntax)
var list1 = (from x in intArray where x % 2 == 0 orderby x select x).Distinct();

Console.WriteLine(string.Join(", ", list1));

// List 2. LINQ (using method syntax)
var list2 = intArray.Where(x => x % 2 == 0).OrderBy(x => x).Distinct();

Console.WriteLine(string.Join(", ", list2));

// Object array
var objectArray = new User[] {
    new User(1, "James"),
    new User(2, "John"),
    new User(3, "Olivia"),
    new User(4, "Michael")
};

// List 3. Object list
var list3 = objectArray.Where(x => x.Name.Contains("J")).OrderByDescending(x => x.Id).FirstOrDefault();

Console.WriteLine(string.Join(", ", list3));
