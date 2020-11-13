#load "factories.csx"

// Create Unicycle
WriteLine(VehicleFactory.Build(1));

// Create Car
WriteLine(VehicleFactory.Build(2));

// Create Motorbike
WriteLine(VehicleFactory.Build(4));

// Create Truck
WriteLine(VehicleFactory.Build(5));
