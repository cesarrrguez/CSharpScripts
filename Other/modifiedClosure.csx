var actions = new List<Action>();

for (int i = 0; i < 5; i++)
{
    var i2 = i;
    actions.Add(() => Console.WriteLine(i2));
}

foreach (var action in actions)
    action();
