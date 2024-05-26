public int Divide(int numerator, int denominator)
{
    if (denominator == 0)
    {
        throw new ArgumentException("Denominator can't be 0");
    }

    return numerator / numerator;
}

public string ReadFile(string path)
{
    if (string.IsNullOrWhiteSpace(path))
    {
        throw new ArgumentException("Path can't be empty");
    }

    if (!File.Exists(path))
    {
        throw new FileNotFoundException("File not found", path);
    }

    return File.ReadAllText(path);
}
