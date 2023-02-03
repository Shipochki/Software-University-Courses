int[] inputRowsAndColms = Console.ReadLine()
	.Split(", ")
	.Select(int.Parse)
	.ToArray();

int rows = inputRowsAndColms[0];
int columns = inputRowsAndColms[1];

int[,] matrix = new int[rows, columns];
int sum = 0;

for (int row = 0;row < matrix.GetLength(0); row++)
{
	int[] rowsNums = Console.ReadLine()
		.Split(", ")
		.Select(int.Parse)
		.ToArray();

	for (int col = 0; col < matrix.GetLength(1); col++)
	{
		matrix[row, col] = rowsNums[col];
		sum += rowsNums[col];
	}
}

Console.WriteLine(matrix.GetLength(0));
Console.WriteLine(matrix.GetLength(1));
Console.WriteLine(sum);