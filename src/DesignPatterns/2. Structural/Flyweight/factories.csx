#load "entities.csx"

// FlyWeight Factory
public class CharacterFactory
{
    private readonly Dictionary<char, Character> _characters = new Dictionary<char, Character>();

    public Character GetCharacter(char key)
    {
        Character character;
        if (_characters.ContainsKey(key))
        {
            character = _characters[key];
        }
        else
        {
            character = key switch
            {
                'A' => new CharacterA(),
                'B' => new CharacterB(),
                'C' => new CharacterC(),
                _ => throw new NotImplementedException(),
            };
            _characters.Add(key, character);
        }
        return character;
    }
}
