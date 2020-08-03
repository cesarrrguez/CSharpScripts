int n = 5;
PrintData(n);

// Shift to left 1 bit
n = n << 1;
PrintData(n);

// Shift to left 3 bit
n = n << 3;
PrintData(n);

// Shift to right 2 bit
n = n >> 2;
PrintData(n);

// Shift to right 3 bit
n = n >> 3;
PrintData(n);

private void PrintData(int number)
{
    string binary = Convert.ToString(number, 2).PadLeft(8, '0');
    Console.WriteLine("Bin: {0}, Dec: {1}", binary, number);
}
