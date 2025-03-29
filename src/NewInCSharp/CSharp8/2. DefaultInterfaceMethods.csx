var plane = new Car();
((IEngine)plane).TurnOn();
((ISteeringWheel)plane).Turn();
((IEngine)plane).TurnOff();

public interface IEngine
{
    public void TurnOn() => WriteLine("Turn on");
    public void TurnOff() => WriteLine("Turn off");
}

public interface ISteeringWheel
{
    public void Turn() => WriteLine("Turn");
}

public class Car : IEngine, ISteeringWheel { }

public class Plane : IEngine, ISteeringWheel { }

public class SmallPlane : Plane { }
