#load "factories.csx"

// Create Unicycle
Console.WriteLine(VehicleFactory.Build(1));

// Create Car
Console.WriteLine(VehicleFactory.Build(2));

// Create Motorbike
Console.WriteLine(VehicleFactory.Build(4));

// Create Truck
Console.WriteLine(VehicleFactory.Build(5));
