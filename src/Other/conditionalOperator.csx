// The Conditional operator provides a fast and simple way of writing if-else statements:
// condition ? first_expression : second_expression;
// If the condition is true, return the first expression, and if the condition is false, 
// return the second expression.
var number = 6;
ConditionalOperatorMethod1(number);
ConditionalOperatorMethod2(number);

private void ConditionalOperatorMethod1(int number)
{
    string message = string.Empty;

    if (number > 5)
    {
        message = $"{number} is greater than 5!";
    }
    else
    {
        message = $"{number} is even or less than 5!";
    }
    Console.WriteLine(message);
}

private void ConditionalOperatorMethod2(int number)
{
    string message = string.Empty;

    message = number > 5 ? $"{number} is greater than 5!" : $"{number} is even or less than 5!";
    Console.WriteLine(message);
}
