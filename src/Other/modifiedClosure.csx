var actions = new List<Action>();

for (var i = 0; i < 5; i++)
{
    var i2 = i;
    actions.Add(() => WriteLine(i2));
}

foreach (var action in actions)
{
    action();
}
