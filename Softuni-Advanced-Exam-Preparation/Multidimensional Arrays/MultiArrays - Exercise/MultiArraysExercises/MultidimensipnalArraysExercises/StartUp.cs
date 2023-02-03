int rows = int.Parse(Console.ReadLine());

int[,] matrix = new int[rows, rows];
int leftDiagonalSum = 0;
int rightDiagonalSum = 0;

for(int row = 0; row < matrix.GetLength(0); row++)
{
    int[] rowLine = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    leftDiagonalSum += rowLine[row];
    rightDiagonalSum += rowLine[matrix.GetLength(0) - row - 1];
}

Console.WriteLine(Math.Abs(leftDiagonalSum - rightDiagonalSum));