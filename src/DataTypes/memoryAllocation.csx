/*
Value types:
bool, byte, sbyte, char, decimal, double, float, int, uint, nint, nuint, long, ulong, short, ushort, struct, enum, tuples

Hints:
    1. Value type declared as variable in method => Stack
    2. Value type declared as parameter in method => Stack
    3. Value type declared as a member of a class => Heap
    4. Value type declared as a member of a struct => Wherever the struct has been allocated
    5. ref structs => Stack always
*/

int number = 420; // Stack
Application application = new();  // Heap

public class Application
{
    private readonly int _number = 21;  // Heap
    private readonly DateStruct _dateStruct = new(); // Heap

    public void PrintNumber() => WriteLine(_number);
    public void PrintDateStruct() => WriteLine(_dateStruct);
    public void PrintNumberFromParameter(int number) => WriteLine(number);  // Stack

    public void PrintDateFromLocalVariables()
    {
        const int day = 18; // Stack
        const int month = 12; // Stack
        const int year = 2021; // Stack

        WriteLine($"The date is {day}/{month}/{year}");
    }

    public void PrintDateFromLocalStruct()
    {
        DateStruct dateStruct = new DateStruct
        {
            Day = 18,
            Month = 12,
            Year = 2021
        }; // Stack

        WriteLine($"The date is {dateStruct.Day}/{dateStruct.Month}/{dateStruct.Year}");
    }

    public void PrintDateFromLocalClass()
    {
        DateClass dateClass = new DateClass
        {
            Day = 18,
            Month = 12,
            Year = 2021
        }; // Heap

        WriteLine($"The date is {dateClass.Day}/{dateClass.Month}/{dateClass.Year}");
    }
}

public struct DateStruct
{
    public int Day { get; init; }
    public int Month { get; init; }
    public int Year { get; init; }
}

public class DateClass
{
    public int Day { get; init; }
    public int Month { get; init; }
    public int Year { get; init; }
}
