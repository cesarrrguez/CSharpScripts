#load "entities.csx"
#load "services.csx"
#load "commands.csx"

// Receiver
var product = new Product("Phone", 500);

// Invoker
var modifyPrice = new ModifyPrice();

// Client
var client = new Client();

// Execute commands
client.Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));
client.Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));
client.Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));

WriteLine();

// Print Receiver
WriteLine(product);
