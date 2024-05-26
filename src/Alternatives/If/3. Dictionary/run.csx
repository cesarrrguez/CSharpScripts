decimal total = 1000;
decimal discount;
decimal tax;

var actions = new Dictionary<Predicate<decimal>, Action>
{
    { t => t < 10, () => tax = total * 0.2m },
    { t => t >= 10 && t < 100, () => tax = total * 0.1m },
    { t => t >= 100 && t < 1000, () => discount = total * 0.2m },
    { t => t >= 1000, () => discount = total * 0.3m }
};

foreach (var action in actions)
{
    if (action.Key(total))
    {
        action.Value();
        break;
    }
}

WriteLine(total + tax - discount); // 700
