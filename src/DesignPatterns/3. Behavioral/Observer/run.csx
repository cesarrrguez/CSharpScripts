#load "services.csx"
#load "observers.csx"

// Observer
var observer = new ConsoleObserver();

// Subject
var productService = new ProductService();

// Subscribe
productService.Subscribe(observer);
productService.AddProduct("Laptop");

WriteLine();

// Unsubscribe
productService.Unsubscribe(observer);
productService.AddProduct("Mouse");
