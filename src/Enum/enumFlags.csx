// The output for this code will be "BlackMamba, CottonMouth, Wiper".
// When the flags attribute is removed, the output will remain 14.

var snakes = 14;
WriteLine((Reptile)snakes);

[Flags]
enum Reptile
{
    None = 0,
    BlackMamba = 2,
    CottonMouth = 4,
    Wiper = 8,
    Crocodile = 16,
    Aligator = 32
}
