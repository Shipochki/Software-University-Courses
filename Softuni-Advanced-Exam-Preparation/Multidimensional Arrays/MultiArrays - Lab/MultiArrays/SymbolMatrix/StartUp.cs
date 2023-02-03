int rows = int.Parse(Console.ReadLine());

char[,] matrix = new char[rows, rows];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string inputLine = Console.ReadLine();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = inputLine[col];
    }
}

char symbol = char.Parse(Console.ReadLine());

for(int row = 0;row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        if (matrix[row, col] == symbol)
        {
            Console.WriteLine($"({row}, {col})");
            return;
        }
    }
}

Console.WriteLine($"{symbol} does not occur in the matrix");