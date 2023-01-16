using System;
using System.Linq;
using System.Text;

namespace SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];

            int max = int.MinValue;

            int[,] matrix = new int[rows, cols];

            string bestFirstRow = string.Empty;
            string bestLastRow = string.Empty;

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int sum = 
                        matrix[row, col] + matrix[row, col + 1] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > max)
                    {
                        max = sum;
                        bestFirstRow =  $"{matrix[row, col]} {matrix[row, col + 1]}";
                        bestLastRow = $"{matrix[row + 1, col]} {matrix[row + 1, col + 1]}"; ;
                    }
                }
            }

            Console.WriteLine(bestFirstRow);
            Console.WriteLine(bestLastRow);
            Console.WriteLine(max);
        }
    }
}
