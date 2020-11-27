#load "entities.csx"

// Create Customer
var customer = new Customer("James");

// Create Order
var order = new Order(new Guid(), DateTime.Now);

// Print Customer
WriteLine(customer);

// Add order
customer.AddOrder(order);

// Print Customer
WriteLine(customer);

// Remove Customer
customer = null;
GC.Collect();

// Print Customer
WriteLine(customer);

// Print Order
WriteLine(order);
