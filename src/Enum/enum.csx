enum Tendency { None, Grow, Fall };
enum Transition { Same = 0, Soft = 23, Hard = 65, Invalid = 78 };

var tendency = Tendency.Grow;
WriteLine($"Tendency: {tendency} ({(int)tendency})\n");

WriteLine($"The values of the '{nameof(Tendency)}' Enum are:");
foreach (var i in Enum.GetValues(typeof(Tendency)))
{
    WriteLine($"{i} = {(int)i}");
}

WriteLine($"\nThe values of the '{nameof(Transition)}' Enum are:");
foreach (var i in Enum.GetValues(typeof(Transition)))
{
    WriteLine($"{i} = {(int)i}");
}
