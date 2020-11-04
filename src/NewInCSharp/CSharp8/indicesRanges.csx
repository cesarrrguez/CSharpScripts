var words = new string[]
{
                // index from start    index from end
    "The",      // 0                   ^9
    "quick",    // 1                   ^8
    "brown",    // 2                   ^7
    "fox",      // 3                   ^6
    "jumped",   // 4                   ^5
    "over",     // 5                   ^4
    "the",      // 6                   ^3
    "lazy",     // 7                   ^2
    "dog"       // 8                   ^1
};              // 9 (or words.Length) ^0

WriteLine($"The last word is {words[^1]}");

var quickBrownFox = words[1..4]; // contains "quick", "brown", "fox"
WriteLine($"\nQuick, Brown and Fox (Range [1..4]): {string.Join(", ", quickBrownFox)}");

var lazyDog = words[^2..^0]; // contains "lazy", "dog"
WriteLine($"Lazy dog (Range [^2..^0]): {string.Join(", ", lazyDog)}");

var allWords = words[..]; // contains "The" through "dog".
WriteLine($"All words (Range [..]): {string.Join(", ", allWords)}");

var firstPhrase = words[..4]; // contains "The" through "fox"
WriteLine($"First phrase (Range [..4]): {string.Join(", ", firstPhrase)}");

var lastPhrase = words[6..]; // contains "the", "lazy" and "dog"
WriteLine($"Last phrase (Range [..4]): {string.Join(", ", lastPhrase)}");

var phrase = 1..4;
var text = words[phrase];
WriteLine($"\nRange 1..4: {string.Join(", ", text)}");
