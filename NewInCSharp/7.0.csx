// Out variables
Write("Out variables: ");
var input = "7";
if (int.TryParse(input, out int result))
    Console.Write(result);
else
    Console.Write("Could not parse input");

// Tuples
var array = new int[] { 55, 67, 100, 34 };
var range = Range(array);
Console.WriteLine($"\nTuples: {range.Item1}, {range.Item2}");

public (int, int) Range(int[] array) => (array.Min(), array.Max());

// Discards
Write("Discards: ");
input = "7";
if (int.TryParse(input, out _))
    Console.Write(input);
else
    Console.Write("Could not parse input");

// Pattern matching
// Is-expressions with patterns
WriteLine("\nPattern matching:");
int value;
object obj = 7;
if (obj is int number)
    value = number;
WriteLine($"-> Is-expressions with patterns: {value}");

// Switch statements with patterns
var list = new List<object>() { 1, 2, 3, new List<int>() { 1, 2, 3 } };
WriteLine($"-> Switch statements with patterns: {SumPositiveNumbers(list)}");

public static int SumPositiveNumbers(IEnumerable<object> sequence)
{
    int sum = 0;
    foreach (var i in sequence)
    {
        switch (i)
        {
            case 0:
                break;
            case IEnumerable<int> childSequence:
                {
                    foreach (var item in childSequence)
                        sum += (item > 0) ? item : 0;
                    break;
                }
            case int n when n > 0:
                sum += n;
                break;
            case null:
                throw new NullReferenceException("Null found in sequence");
            default:
                throw new InvalidOperationException("Unrecognized type");
        }
    }
    return sum;
}

// Local functions
Console.WriteLine($"Local functions: {GetValue1()}");

public int GetValue1()
{
    return 1 + GetValue2();

    int GetValue2() => 2;
}
