#load "entities.csx"

// Create Customer
Customer customer = new Customer("James");

// Create Order
Order order = new Order(new Guid(), DateTime.Now);

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
