#load "exceptions.csx"

public class Heating
{
    private const int MAX_TEMPERATURE = 120;

    public string Name { get; }
    public int Temperature { get; private set; }
    public bool Works { get; private set; }

    public Heating(string name, int temperature)
    {
        Name = name ?? throw new ArgumentNullException(name);
        Temperature = temperature;
        Works = true;
    }
    public bool IsOk() => throw new NotImplementedException();

    public void TurnOff()
    {
        Temperature = 0;
        WriteLine("Heating '{0}' is off", Name);
    }

    public void Work(int temperatureIncrease)
    {
        if (temperatureIncrease < 0)
            throw new ArgumentException("Increase", "Increase can´t be a negative number");

        if (!Works)
        {
            WriteLine("Heating '{0}' doesn't works", Name);
        }
        else
        {
            Temperature += temperatureIncrease;
            WriteLine("Current temperature is {0}", Temperature);

            if (Temperature > MAX_TEMPERATURE)
            {
                WriteLine("Heating '{0}' exceed the maximun temperature, has {1}", Name, Temperature);
                Temperature = MAX_TEMPERATURE;
                Works = false;

                var ex = new HeatingException(string.Format("Heating '{0}' overheats", Name), "Has worked too long", DateTime.Now)
                {
                    HelpLink = "https://cesarrrguez.github.io/"
                };

                // Create data exception
                ex.Data.Add("Current temperature:", String.Format("{0} degrees", Temperature));
                ex.Data.Add("Temperature increase:", String.Format("{0} degrees", temperatureIncrease));

                // Throw exception
                throw ex;
            }
        }
    }
}
