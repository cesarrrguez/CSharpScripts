var matrix = new int[4, 2];

InitializeMatrix(matrix);
PrintMatrix(matrix);

public void InitializeMatrix(int[,] matrix)
{
    var random = new Random();

    for (var i = 0; i < 4; i++)
    {
        for (var j = 0; j < 2; j++)
        {
            matrix[i, j] = random.Next(1, 10);
        }
    }
}

public void PrintMatrix(int[,] matrix)
{
    for (var i = 0; i < 4; i++)
    {
        for (var j = 0; j < 2; j++)
        {
            Console.Write("{0} ", matrix[i, j]);
        }
        Console.WriteLine();
    }
}
