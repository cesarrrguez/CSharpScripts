#load "services.csx"

// Example 1
try
{
    var result = Divide(10, 0);
    WriteLine(result);
}
catch (Exception ex)
{
    WriteLine(ex.Message); // Denominator can't be 0
}

// Example 2
try
{
    var resultContent = ReadFile("a.txt");
    WriteLine(resultContent);
}
catch (Exception ex)
{
    WriteLine(ex.Message); // File not found
}
