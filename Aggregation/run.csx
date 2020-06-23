// Aggregation
// ---------------------------------
// Description: 'has-a' relationship
// ---------------------------------
// UML: Customer <> ----- Order
// ---------------------------------

#load "entities.csx"

// Create Customer
Customer customer = new Customer("James");

// Create Order
Order order = new Order(new Guid(), DateTime.Now);

// Print Customer
Console.WriteLine(customer);

// Add order
customer.AddOrder(order);

// Print Customer
Console.WriteLine(customer);

// Remove Customer
customer = null;
GC.Collect();

// Print Customer
Console.WriteLine(customer);

// Print Order
Console.WriteLine(order);
