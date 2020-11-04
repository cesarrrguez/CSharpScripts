#load "interfaces.csx"

public class Unicycle : IVehicle
{
    public override string ToString() => this.GetType().Name;
}

public class Car : IVehicle
{
    public override string ToString() => this.GetType().Name;
}

public class Motorbike : IVehicle
{
    public override string ToString() => this.GetType().Name;
}

public class Truck : IVehicle
{
    public override string ToString() => this.GetType().Name;
}
