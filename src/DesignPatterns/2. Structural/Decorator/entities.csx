#load "interfaces.csx"

// Component 1
public class GasolineCar : ICar
{
    public double GetPrice() => 100;
    public string GetDetails() => "Gasoline Car";
}

// Component 2
public class ElectricCar : ICar
{
    public double GetPrice() => 200;
    public string GetDetails() => "Electric Car";
}

// Decorator
public abstract class CarAccessory : ICar
{
    private readonly ICar _car;

    protected CarAccessory(ICar car)
    {
        _car = car ?? throw new ArgumentNullException(nameof(car));
    }

    public virtual double GetPrice() => _car.GetPrice();
    public virtual string GetDetails() => _car.GetDetails();
}

// Decorator A
public class SecurityPackage : CarAccessory
{
    public SecurityPackage(ICar car) : base(car) { }

    public override double GetPrice() => base.GetPrice() + 20;
    public override string GetDetails() => base.GetDetails() + " + Security Package";
}

// Decorator B
public class SportPackage : CarAccessory
{
    public SportPackage(ICar car) : base(car) { }

    public override double GetPrice() => base.GetPrice() + 50;
    public override string GetDetails() => base.GetDetails() + " + Sport Package";
}
