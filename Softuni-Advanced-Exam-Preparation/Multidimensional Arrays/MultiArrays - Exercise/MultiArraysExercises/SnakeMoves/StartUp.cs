int[] sizeMatrix = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int rows = sizeMatrix[0];
int cols = sizeMatrix[1];

char[,] matrix = new char[rows, cols];

string word = Console.ReadLine();
    int currentIndex = 0;

for (int row = 0;row < matrix.GetLength(0); row++)
{
    if (row % 2 == 0)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            matrix[row, col] = word[currentIndex];
            currentIndex++;
            if (currentIndex == word.Length)
            {
                currentIndex = 0;
            }
        }
    }
    else
    {
        for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
        {
            matrix[row, col] = word[currentIndex];
            currentIndex++;
            if (currentIndex == word.Length)
            {
                currentIndex = 0;
            }
        }
    }
}

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write(matrix[row,col]);
    }
    Console.WriteLine();
}
    