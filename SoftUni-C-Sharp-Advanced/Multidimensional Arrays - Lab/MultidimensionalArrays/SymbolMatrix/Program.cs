using System;
using System.Linq;

namespace SymbolMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int square = int.Parse(Console.ReadLine());

            string[,] matrix = new string[square, square];

            string input = string.Empty;

            for (int row = 0; row < square; row++)
            {
                input = Console.ReadLine();
                for (int col = 0; col < square; col++)
                {
                    matrix[row, col] = input[col].ToString();
                }
            }

            input = Console.ReadLine();

            for (int row = 0; row < square; row++)
            {
                for (int col = 0; col < square; col++)
                {
                    if (matrix[row, col] == input)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{input} does not occur in the matrix");
        }
    }
}
