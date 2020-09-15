// Null-coalescing assignment
List<int> numbers = null;
int? i = null;

numbers ??= new List<int>();
numbers.Add(i ??= 17);
numbers.Add(i ??= 20);

WriteLine(string.Join(" ", numbers));  // output: 17 17
WriteLine(i);  // output: 17
