#load "entities.csx"

var pizza = Chef.MakePizza();
Chef.MakeDrink();

pizza.Wait();

Console.WriteLine("Food finished");
