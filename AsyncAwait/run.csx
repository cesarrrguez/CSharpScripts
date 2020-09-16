#load "entities.csx"

var pizza = Chef.MakePizza();
Chef.MakeDrink();

pizza.Wait();
//await pizza.ConfigureAwait(false); // Alternative 1
//Task.WaitAll(pizza); // Alternative 2

Console.WriteLine("Food finished");
