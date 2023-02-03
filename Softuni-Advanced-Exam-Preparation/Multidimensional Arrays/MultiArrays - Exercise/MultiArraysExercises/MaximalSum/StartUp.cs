using System;
using System.Linq;

int[] rowsAndColsParm = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = rowsAndColsParm[0];
int cols = rowsAndColsParm[1];

int[,] matrix = new int[rows, cols];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] splitedInputData = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = splitedInputData[col];
    }
}

int sum = int.MinValue;
int maxRow = 0;
int maxCol = 0;

for (int row = 0; row < matrix.GetLength(0) - 2; row++)
{
    for (int col = 0; col < matrix.GetLength(1) - 2; col++)
    {
        int currentSum =
            matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
            matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
            matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

        if (currentSum > sum)
        {
            sum = currentSum;
            maxRow= row;
            maxCol = col;
        }
    }
}

Console.WriteLine($"Sum = {sum}");
for (int row = maxRow; row < maxRow+3; row++)
{
    for (int col = maxCol; col < maxCol+3; col++)
    {
        Console.Write(matrix[row, col] + " ");
    }
    Console.WriteLine();
}