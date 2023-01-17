using System;
using System.Linq;

namespace SquaresMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            string[,] matrix = new string[rows, cols];

            int countSquares = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] chars = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col + 1] == matrix[row + 1, col] &&
                        matrix[row + 1, col] == matrix[row + 1, col + 1])
                    {
                        countSquares++;
                    }
                }
            }

            Console.WriteLine(countSquares);
        }
    }
}
