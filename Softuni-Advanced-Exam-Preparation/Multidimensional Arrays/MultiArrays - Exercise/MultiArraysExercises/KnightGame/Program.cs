int size = int.Parse(Console.ReadLine());
char[,] matrix = new char[size, size];

for(int row = 0;row < matrix.GetLength(0); row++)
{
	string inputData = Console.ReadLine();
	for (int col = 0; col < matrix.GetLength(1); col++)
	{
		matrix[row, col] = inputData[col];
	}
}

char knight = 'K';

for (int row = 0; row < matrix.GetLength(0); row++)
{
	for (int col = 0; col < matrix.GetLength(1); col++)
	{
		if (matrix[row,col] == knight)
		{

		}
	}
}