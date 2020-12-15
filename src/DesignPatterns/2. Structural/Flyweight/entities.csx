// Flyweight
public abstract class Character
{
    protected char Symbol;
    protected int Size;

    public void Display(int size)
    {
        Size = size;
        WriteLine($"Symbol: {Symbol}, Size: {Size}");
    }
}

// Flyweight 1
public class CharacterA : Character
{
    public CharacterA() => Symbol = 'A';
}

// Flyweight 2
public class CharacterB : Character
{
    public CharacterB() => Symbol = 'B';
}

// Flyweight 3
public class CharacterC : Character
{
    public CharacterC() => Symbol = 'C';
}
