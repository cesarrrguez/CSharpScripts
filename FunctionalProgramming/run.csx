#load "entities.csx"
#load "utils.csx"

var users = new List<User>()
{
    new User { Name = "Christopher", Enabled = true },
    new User { Name = "Olivia", Enabled = false },
    new User { Name = "James", Enabled = true }
};

// Imperative
WriteLine("Imperative:");
var enabledUserNames = new List<string>();
foreach (var user in users)
{
    if (user.Enabled)
        enabledUserNames.Add(user.Name);
}
foreach (var name in enabledUserNames)
{
    WriteLine(name);
}

// Functional
WriteLine("\nFunctional:");
var enabledUserNames2 = users.Where(x => x.Enabled).Select(x => x.Name).ToList();
enabledUserNames2.ForEach(x => WriteLine(x));

WriteLine();

var text = Utils.Concat("Hello", "World");
WriteLine(text);

var days = Utils.Days(new DateTime(2020, 08, 15), DateTime.Now);
WriteLine($"{days} days");
