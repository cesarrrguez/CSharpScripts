enum Tendency { None, Grow, Fall };
enum Transition { Same = 0, Soft = 23, Hard = 65, Invalid = 78 };

Console.WriteLine($"The values of {nameof(Tendency)} Enum are:");
foreach (var i in Enum.GetValues(typeof(Tendency)))
    Console.WriteLine($"{i} = {(int)i}");

Console.WriteLine($"\nThe values of the {nameof(Transition)} Enum are:");
foreach (var i in Enum.GetValues(typeof(Transition)))
    Console.WriteLine($"{i} = {(int)i}");
