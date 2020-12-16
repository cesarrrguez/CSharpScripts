#load "entities.csx"

var driver1 = new Driver(25);
var driver2 = new Driver(15);

// Driver 1
ICar car = new ProxyCar(driver1);
car.DriveCar();

// Driver 2
ICar car2 = new ProxyCar(driver2);
car2.DriveCar();
