WriteLine(Round(535));

private static int Round(int n)
{
    // Smaller multiple 
    int a = (n / 10) * 10;

    // Larger multiple 
    int b = a + 10;

    // Return of closest of two 
    return (n - a > b - n) ? b : a;
}
