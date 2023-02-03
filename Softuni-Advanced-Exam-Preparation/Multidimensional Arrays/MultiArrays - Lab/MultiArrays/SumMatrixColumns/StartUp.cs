int[] inputRowsAndColms = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();

int rows = inputRowsAndColms[0];
int columns = inputRowsAndColms[1];

int[] resultForColums = new int[columns];

int[,] matrix = new int[rows, columns];
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
        sum += rowsNums[col];
        resultForColums[col] += rowsNums[col];
    }
}

foreach (var currentResult in resultForColums)
{
    Console.WriteLine(currentResult);
}