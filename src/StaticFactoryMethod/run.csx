#load "entities.csx"

var pizzaNormal = Pizza.GetPizza();
var pizzaLarge = Pizza.GetLargePizza();
var pizzaSmall = Pizza.GetSmallPizza();

WriteLine(pizzaNormal);
WriteLine(pizzaLarge);
WriteLine(pizzaSmall);
