public class Car
{
    private readonly string _name;
    private readonly Engine _engine;

    public Car(string name)
    {
        _name = name ?? throw new ArgumentNullException(nameof(name));
        _engine = new Engine("Electric", 100);
    }

    public override string ToString()
    {
        var result = $"Car. Name: {_name}";

        if (_engine != null)
        {
            result += $"\n{_engine}";
        }

        return result;
    }
}

public class Engine
{
    private readonly string _type;
    private readonly int _power;

    public Engine(string type, int power)
    {
        _type = type ?? throw new ArgumentNullException(nameof(type));
        _power = power;
    }

    public override string ToString() => $"Engine. Type: {_type}, Power: {_power}";
}
