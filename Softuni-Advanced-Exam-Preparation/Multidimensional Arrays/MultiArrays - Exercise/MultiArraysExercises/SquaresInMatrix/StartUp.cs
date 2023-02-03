int[] rowsAndColsParm = Console.ReadLine()
	.Split()
	.Select(int.Parse)
	.ToArray();

int rows = rowsAndColsParm[0];
int cols = rowsAndColsParm[1];

string[,] matrix = new string[rows, cols];
string firstLine = string.Empty;
string lastLine = string.Empty;

for (int row = 0;row < matrix.GetLength(0); row++)
{
	string[] splitedInputData = Console.ReadLine()
		.Split()
		.ToArray();

	for (int col = 0; col < matrix.GetLength(1); col++)
	{
		matrix[row, col] = splitedInputData[col];
	}
}

int countSquare = 0;

for (int row = 0; row < matrix.GetLength(0) - 1; row++)
{
	for (int col = 0; col < matrix.GetLength(1) - 1; col++)
	{
		if (matrix[row, col] == matrix[row, col + 1] &&
			matrix[row, col] == matrix[row + 1, col] &&
			matrix[row, col] == matrix[row + 1, col + 1])
		{
			countSquare++;
		}
	}
}

Console.WriteLine(countSquare);