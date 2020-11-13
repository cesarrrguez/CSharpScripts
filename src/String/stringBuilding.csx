string name = "James";
int age = 21;

string text = ""; // Setting it to null would cause additional problems.

// Way 1. String concatenation
text = "Name: " + name + ", Age: " + age;
WriteLine(text);

// Way 2. Composite formatting
text = string.Format("Name: {0}, Age: {1}", name, age);
WriteLine(text);

// Way 3. StringBuilder append
var builder = new StringBuilder();
builder.Append("Name: ");
builder.Append(name);
builder.Append(", Age: ");
builder.Append(age);
text = builder.ToString();
WriteLine(text);

// Way 4. String interpolation
text = $"Name: {name}, Age: {age}";
WriteLine(text);
