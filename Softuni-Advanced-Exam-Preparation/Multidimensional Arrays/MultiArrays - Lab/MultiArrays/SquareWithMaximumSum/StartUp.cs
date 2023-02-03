using System.Text;

int[] inputRowsAndColms = Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    .ToArray();

int rows = inputRowsAndColms[0];
int columns = inputRowsAndColms[1];

int[,] matrix = new int[rows, columns];
int sum = 0;

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] rowsNums = Console.ReadLine()
        .Split(", ")
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = rowsNums[col];
    }
}

string firstLine = string.Empty;
string lastLine = string.Empty;

for (int row = 0; row < matrix.GetLength(0) - 1; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
    {
        int currentSubMatrix = matrix[row, col] + 
            matrix[row + 1, col] + 
            matrix[row, col + 1] + 
            matrix[row + 1, col + 1];
        if(currentSubMatrix > sum)
        {
            firstLine = $"{matrix[row, col]} {matrix[row, col + 1]}";
            lastLine = $"{matrix[row + 1, col]} {matrix[row + 1, col + 1]}";
            sum = currentSubMatrix;
        }
    }
}

Console.WriteLine(firstLine);
Console.WriteLine(lastLine);
Console.WriteLine(sum);
