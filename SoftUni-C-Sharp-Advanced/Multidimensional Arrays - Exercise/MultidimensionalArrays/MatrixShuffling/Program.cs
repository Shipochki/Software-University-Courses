using System;
using System.Linq;

namespace MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            string[,] matrix = new string[rows, cols];

            FillMatrix(matrix);

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Split()[0] == "END")
                {
                    break;
                }

                if (IsCorrectInput(input, rows, cols))
                {
                    string[] text = input.Split();

                    int row1 = int.Parse(text[1]);
                    int col1 = int.Parse(text[2]);
                    int row2 = int.Parse(text[3]);
                    int col2 = int.Parse(text[4]);

                    string first = matrix[row1, col1];
                    string second = matrix[row2, col2];

                    matrix[row1, col1] = second;
                    matrix[row2, col2] = first;

                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
        static bool IsCorrectInput(string input, int rows, int cols)
        {
            string[] text = input.Split();
            string comand = text[0];

            if (text.Length == 5 && comand == "swap")
            {
                int row1 = int.Parse(text[1]);
                int col1 = int.Parse(text[2]);
                int row2 = int.Parse(text[3]);
                int col2 = int.Parse(text[4]);

                if (row1 >= 0 && row1 < rows &&
                    col1 >= 0 && col1 < cols &&
                    row2 >= 0 && row2 < rows &&
                    col2 >= 0 && col2 < cols)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
