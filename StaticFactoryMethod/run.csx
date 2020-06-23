#load "entities.csx"

var pizzaNormal = Pizza.GetPizza();
var pizzaLarge = Pizza.GetLargePizza();
var pizzaSmall = Pizza.GetSmallPizza();

Console.WriteLine(pizzaNormal);
Console.WriteLine(pizzaLarge);
Console.WriteLine(pizzaSmall);
