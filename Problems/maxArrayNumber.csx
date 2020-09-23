// Max array number
// -------------------------------------------------
// Get the maximum number in an array without loops.
// -------------------------------------------------

int[] array = { 50, -1500, 1000, 0, 1, 54 };

var result = MaxArrayNumber(array);
WriteLine($"Maximum number is: {result}");

public static int MaxArrayNumber(int[] array) => array.Aggregate((acc, x) => acc > x ? acc : x);
