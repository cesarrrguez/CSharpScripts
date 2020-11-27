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
    WriteLine(message);
}

private void ConditionalOperatorMethod2(int number)
{
    var message = string.Empty;

    message = number > 5 ? $"{number} is greater than 5!" : $"{number} is even or less than 5!";
    WriteLine(message);
}
