var bartender = new Bartender(ReadLine, WriteLine);

while (true)
{
    bartender.AskForDrink();
}

public class Bartender
{
    private readonly Func<string> _inputProvider;
    private readonly Action<string> _outputProvider;

    public Bartender(Func<string> inputProvider, Action<string> outputProvider)
    {
        _inputProvider = inputProvider;
        _outputProvider = outputProvider;
    }

    public void AskForDrink()
    {
        _outputProvider("What drink do you want? (beer, juice)");

        var drink = _inputProvider() ?? string.Empty;

        if (drink.Equals("beer"))
        {
            _outputProvider("Not so fast cowboy. How old are you?");

            if (!int.TryParse(_inputProvider(), out var age))
            {
                _outputProvider("Could not parse the age provided");
            }
            else
            {
                if (age >= 18)
                {
                    _outputProvider("Here you go! Cold beer");
                }
                else
                {
                    _outputProvider("Sorry but you´re not old enough to drink");
                }
            }
        }
        else if (drink.Equals("Juice"))
        {
            _outputProvider("Here you go! Fresh and nice juice");
        }
        else
        {
            _outputProvider($"Sorry mate but we don´t do {drink}");
        }
    }
}
