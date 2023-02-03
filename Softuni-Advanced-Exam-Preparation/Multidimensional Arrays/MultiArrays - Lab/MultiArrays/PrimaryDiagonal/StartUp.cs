int rows = int.Parse(Console.ReadLine());

int[,] matrix = new int[rows, rows];
int sum = 0;

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] rowsNums = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = rowsNums[col];
    }
    sum += matrix[row, row];
}

Console.WriteLine(sum);
