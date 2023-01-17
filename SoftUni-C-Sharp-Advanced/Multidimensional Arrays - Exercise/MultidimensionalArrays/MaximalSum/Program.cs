using System;
using System.Linq;

namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            int max = 0;
            string firstLine = string.Empty;
            string secondLine = string.Empty;
            string thirdLine = string.Empty;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > max)
                    {
                        max = sum;
                        firstLine = $"{matrix[row, col]} {matrix[row, col + 1]} {matrix[row, col + 2]}";
                        secondLine = $"{matrix[row + 1, col]} {matrix[row + 1, col + 1]} {matrix[row + 1, col + 2]}";
                        thirdLine = $"{matrix[row + 2, col]} {matrix[row + 2, col + 1]} {matrix[row + 2, col + 2]}";
                    }
                }
            }

            Console.WriteLine($"Sum = {max}");
            Console.WriteLine(firstLine);
            Console.WriteLine(secondLine);
            Console.WriteLine(thirdLine);

        }
    }
}
