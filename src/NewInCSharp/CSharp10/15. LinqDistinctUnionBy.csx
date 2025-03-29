// DistinctBy
public record Beer(string Name, string Brand);

var beers = new Beer[]
{
    new("Pikantus", "Erdinger"),
    new("London Porter", "Fuller´s"),
    new("IPA", "Fuller´s"),
    new("Red", "Delirium"),
    new("Dunkel", "Erdinger"),
};

foreach (var beer in beers.DistinctBy(b => b.Brand))
{
    WriteLine(beer.Brand);
}

// Erdinger
// Fuller´s
// Delirium

WriteLine();

// UnionBy
var beers2 = new Beer[]
{
    new("Stout", "Minerva"),
    new("Pale Ale", "Minerva"),
    new("Tremens", "Delirium")
};

foreach (var beer in beers.UnionBy(beers2, b => b.Brand))
{
    WriteLine($"{beer.Name} {beer.Brand}");
}

// Pikantus Erdinger
// London Porter Fuller´s
// Red Delirium
// Stout Minerva
