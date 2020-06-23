var section = 0;
var separator = new string(Enumerable.Repeat('-', 40).ToArray());
Action<string> beginSection = title => Console.WriteLine($"{separator}\n{++section}) {title}:\n");

beginSection("Section A");

beginSection("Section B");

beginSection("Section C");
