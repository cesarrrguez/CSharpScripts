#load "entities.csx"

Task<bool> pizza = Chef.MakePizzaAsync();
Chef.MakeDrink();

await pizza;
// Alternative 1: pizza.Wait();
// Alternative 2: Task.WaitAll(pizza);

WriteLine("Food finished");
