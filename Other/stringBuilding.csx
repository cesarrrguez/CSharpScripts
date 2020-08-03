string name = "James";
int age = 21;

string text = ""; // Setting it to null would cause additional problems.

// Way 1
text = "Name: " + name + ", Age: " + age;
Console.WriteLine(text);

// Way 2
text = string.Format("Name: {0}, Age: {1}", name, age);
Console.WriteLine(text);

// Way 3
var builder = new StringBuilder();
builder.Append("Name: ");
builder.Append(name);
builder.Append(", Age: ");
builder.Append(age);
text = builder.ToString();
Console.WriteLine(text);

// Way 4
text = $"Name: {name}, Age: {age}";
Console.WriteLine(text);
