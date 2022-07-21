var text = Concat("Hello", "World");
WriteLine(text);

public string Concat(string text1, string text2) => $"{text1} {text2}";
