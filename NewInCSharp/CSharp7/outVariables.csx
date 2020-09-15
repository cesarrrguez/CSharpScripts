var input = "7";

// With type
if (int.TryParse(input, out int result))
    WriteLine(result);
else
    WriteLine("Could not parse input");

// With var
if (int.TryParse(input, out var answer))
    WriteLine(answer);
else
    WriteLine("Could not parse input");
