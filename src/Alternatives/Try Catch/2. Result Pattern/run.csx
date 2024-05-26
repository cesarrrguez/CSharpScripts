#load "services.csx"

// Example 1
var result = Divide(10, 0);
if (result.IsSuccess)
{
    WriteLine(result.Value);
}
else
{
    WriteLine(result.Error); // Denominator can´t be 0
}

// Example 2
var resultContent = ReadFile("a.txt");
if (resultContent.IsSuccess)
{
    WriteLine(resultContent.Value);
}
else
{
    WriteLine(resultContent.Error); // File not found
}
