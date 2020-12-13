#load "entities.csx"

ICar gasolineCar = new GasolineCar();
ICar upgradedCar = new SportPackage(gasolineCar);
upgradedCar = new SecurityPackage(upgradedCar);

WriteLine($"Details: {upgradedCar.GetDetails()}, Price: {upgradedCar.GetPrice()}");
