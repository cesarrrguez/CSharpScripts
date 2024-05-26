#load "entities.csx"

public Result<int> Divide(int numerator, int denominator)
{
    if (denominator == 0)
    {
        return Result<int>.Failure("Denominator can´t be 0");
    }

    return Result<int>.Success(numerator / numerator);
}

public Result<string> ReadFile(string path)
{
    if (string.IsNullOrWhiteSpace(path))
    {
        return Result<string>.Failure("Path can´t be empty");
    }

    if (!File.Exists(path))
    {
        return Result<string>.Failure("File not found");
    }

    return Result<string>.Success(File.ReadAllText(path));
}
