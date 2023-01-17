using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(el => el * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(el => el * 2).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(el => el / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(el => el / 2).ToArray();
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] text = input.Split();

                int row = int.Parse(text[1]);
                int col = int.Parse(text[2]);
                int value = int.Parse(text[3]);

                bool isCorrect = false;

                if (matrix.GetLength(0) > row && row >= 0)
                {
                    if (matrix[row].GetLength(0) > col && col >= 0 &&
                                        text.Length == 4)
                    {
                        isCorrect = true;
                    }
                }

                if (text[0] == "Add" && isCorrect)
                {
                    matrix[row][col] += value;
                }
                else if (text[0] == "Subtract" && isCorrect)
                {
                    matrix[row][col] -= value;
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].GetLength(0); col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
