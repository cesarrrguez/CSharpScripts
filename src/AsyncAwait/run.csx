#load "entities.csx"

Task<bool> pizza = Chef.MakePizzaAsync();
Chef.MakeDrink();

pizza.Wait();
//await pizza; // Alternative 1
//Task.WaitAll(pizza); // Alternative 2

WriteLine("Food finished");
