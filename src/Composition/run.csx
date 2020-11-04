// Composition
// -----------------------------------
// Description: 'part-of' relationship 
// -----------------------------------
// UML: Engine  ----- <filled> Car
// -----------------------------------

#load "entities.csx"

// Create Car
Car car = new Car("Tesla");

// Print Car
Console.WriteLine(car);

// Remove Car
car = null;
GC.Collect();

// Print Car
Console.WriteLine(car);
