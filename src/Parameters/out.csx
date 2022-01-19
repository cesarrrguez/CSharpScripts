var couldParse = int.TryParse("hello", out int parsedValue);
WriteLine(parsedValue);

int value = 5;
ExmpleOut(out value);
WriteLine(value);

public void ExmpleOut(out int value)
{
    value = 20;
}
