var recipeBook = new RecipeBook(ReadLine, WriteLine);
var bartender = new Bartender(ReadLine, WriteLine, recipeBook);

while (true)
{
    bartender.AskForDrink();
}

public class Bartender
{
    private readonly Func<string> _inputProvider;
    private readonly Action<string> _outputProvider;
    private readonly RecipeBook _recipeBook;

    public Bartender(Func<string> inputProvider, Action<string> outputProvider, RecipeBook recipeBook)
    {
        _inputProvider = inputProvider;
        _outputProvider = outputProvider;
        _recipeBook = recipeBook;
    }

    public void AskForDrink()
    {
        _outputProvider($"What drink do you want? ({string.Join(", ", _recipeBook.GetAvailableDrinkNames())})");

        var drink = _inputProvider() ?? string.Empty;

        if (!_recipeBook.GetAvailableDrinkNames().Contains(drink))
        {
            _outputProvider($"Sorry mate but we don´t do {drink}");
            return;
        }

        _recipeBook.MakeDrink(drink);
    }
}

public class RecipeBook
{
    private readonly Dictionary<string, Action> _recipes;
    private readonly Func<string> _inputProvider;
    private readonly Action<string> _outputProvider;

    public RecipeBook(Func<string> inputProvider, Action<string> outputProvider)
    {
        _inputProvider = inputProvider;
        _outputProvider = outputProvider;

        _recipes = new Dictionary<string, Action>
        {
            {"beer", ServeBeer},
            {"juice", ServeJuice}
        };
    }

    public IEnumerable<string> GetAvailableDrinkNames()
    {
        return _recipes.Keys;
    }

    public void MakeDrink(string drink)
    {
        _recipes[drink]();
    }

    private void ServeBeer()
    {
        _outputProvider("Not so fast cowboy. How old are you?");

        if (!int.TryParse(_inputProvider(), out var age))
        {
            HandleInvalidAge();
            return;
        }

        HandleBeerAgeCheck(age);
    }

    private void ServeJuice()
    {
        _outputProvider("Here you go! Fresh and nice juice");
    }

    private void HandleInvalidAge()
    {
        _outputProvider("Could not parse the age provided");
    }

    private void HandleBeerAgeCheck(int age)
    {
        if (age >= 18)
        {
            _outputProvider("Here you go! Cold beer");
            return;
        }

        _outputProvider("Sorry but you´re not old enough to drink");
    }
}
