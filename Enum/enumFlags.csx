// The output for this code will be "BlackMamba, CottonMouth, Wiper".
// When the flags attribute is removed, the output will remain 14.

int snakes = 14;
Console.WriteLine((Reptile)snakes);

[Flags]
enum Reptile
{
    BlackMamba = 2,
    CottonMouth = 4,
    Wiper = 8,
    Crocodile = 16,
    Aligator = 32
}
