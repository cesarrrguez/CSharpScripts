#load "interfaces.csx"

// Real Subject
public class Car : ICar
{
    public void DriveCar() => WriteLine("Car has been driven!");
}

public class Driver
{
    public int Age { get; set; }
    public Driver(int age) => Age = age;
}

// Proxy
public class ProxyCar : ICar
{
    private readonly Driver _driver;
    private readonly ICar _realCar;

    public ProxyCar(Driver driver)
    {
        _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        _realCar = new Car();
    }

    public void DriveCar()
    {
        if (_driver.Age < 16)
        {
            WriteLine("Sorry, the driver is too young to drive.");
        }
        else
        {
            _realCar.DriveCar();
        }
    }
}
