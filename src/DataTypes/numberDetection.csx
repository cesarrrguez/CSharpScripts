NumberDetection("");
NumberDetection("37");
NumberDetection("5.9");
NumberDetection("Hello World!");

private void NumberDetection(string text)
{
    int ri = 0;
    double rd = 0.0;

    if (string.IsNullOrEmpty(text))
    {
        WriteLine("There is no data");
    }
    else if (int.TryParse(text, out ri))
    {
        WriteLine("Is an integer number");
    }
    else if (double.TryParse(text, out rd))
    {
        WriteLine("Is a float number");
    }
    else
    {
        WriteLine("Is a string");
    }
}
