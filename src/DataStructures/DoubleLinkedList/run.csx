#load "entities.csx"

var list = new DoubleLinkedList<int>();

// Add first
list.AddFirst(1);
WriteLine($"Add first 1: {string.Join(" - ", list.ToList())}");

list.AddFirst(2);
WriteLine($"Add first 2: {string.Join(" - ", list.ToList())}");

// Add last
list.AddLast(3);
WriteLine($"Add last 3: {string.Join(" - ", list.ToList())}");

// Add after
var lastNode = list.GetLastNode();
list.AddAfter(lastNode, 4);
WriteLine($"Add after last 4: {string.Join(" - ", list.ToList())}");

// Add before
lastNode = list.GetLastNode();
list.AddBefore(lastNode, 5);
WriteLine($"Add before last 5: {string.Join(" - ", list.ToList())}");

// Add after
list.AddAfter(5, 6);
WriteLine($"Add after 5, 6: {string.Join(" - ", list.ToList())}");

// Add before
list.AddBefore(5, 7);
WriteLine($"Add before 5, 7: {string.Join(" - ", list.ToList())}");

// Find
var node = list.Find(3);
WriteLine($"Find 3: {node}");

// Find by index
node = list.FindByIndex(3);
WriteLine($"Find by index 3: {node}");

// Find previous
node = list.FindPrevious(3);
WriteLine($"Find previous 3: {node}");

// Find index
var nodeIndex = list.FindIndex(3);
WriteLine($"Find index 3: {nodeIndex}");

// Remove
list.Remove(3);
WriteLine($"Remove 3: {string.Join(" - ", list.ToList())}");

// Reverse
list.Reverse();
WriteLine($"Reverse: {string.Join(" - ", list.ToList())}");

// Get value by index
var value = list[3];
WriteLine($"Get [3]: {value}");

// Set value by index
list[3] = 55;
WriteLine($"Set [3] to 55: {string.Join(" - ", list.ToList())}");

// Count
WriteLine($"Count: {list.Count()}");

// Clear
list.Clear();
WriteLine($"Clear: {string.Join(" - ", list.ToList())}");
