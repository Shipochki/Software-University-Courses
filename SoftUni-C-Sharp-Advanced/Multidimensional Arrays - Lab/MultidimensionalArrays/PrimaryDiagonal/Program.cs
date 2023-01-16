using System;
using System.Linq;

namespace PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nSquare = int.Parse(Console.ReadLine());

            long[,] matrix = new long[nSquare, nSquare];

            long sum = 0;

            for (int row = 0; row < nSquare; row++)
            {
                int[] nums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < nSquare; col++)
                {
                    matrix[row, col] = nums[col];         
                }
                sum += matrix[row, row];
            }

            Console.WriteLine(sum);
        }
    }
}
