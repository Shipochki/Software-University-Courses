using System;
using System.Linq;

namespace DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int row = 0; row < size; row++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = nums[col];
                }
                primaryDiagonal += matrix[row, row];
                int last = size - row;
                secondaryDiagonal += matrix[row, last - 1];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
            
        }
    }
}
