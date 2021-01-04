public const int number = 5;

Func<string> toString = static () => number.ToString();
WriteLine(toString()); // 5
