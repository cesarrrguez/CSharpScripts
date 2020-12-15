#load "factories.csx"

string document = "ABBBAAAC";
char[] chars = document.ToCharArray();

// Factory
CharacterFactory factory = new CharacterFactory();

// Extrinsic state
int size = 10;

// For each character use a flyweight object
foreach (var c in chars)
{
    var character = factory.GetCharacter(c);
    character.Display(size);
    size++;
}
