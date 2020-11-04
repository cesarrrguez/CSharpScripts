#load "entities.csx"

public static class VehicleFactory
{
    public static IVehicle Build(int numberOfWheels)
    {
        switch (numberOfWheels)
        {
            case 1:
                return new Unicycle();

            case 2:
            case 3:
                return new Motorbike();

            case 4:
                return new Car();

            default:
                return new Truck();
        }
    }
}
