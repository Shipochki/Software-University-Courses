using System;
using System.Linq;

namespace SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            string snake = Console.ReadLine();
            int countSnake = 0;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[countSnake];
                        countSnake++;
                        if (countSnake == snake.Length)
                        {
                            countSnake = 0;
                        }
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[countSnake];
                        countSnake++;
                        if (countSnake == snake.Length)
                        {
                            countSnake = 0;
                        }
                    }
                }
                PrintMatrix(matrix, row);

            }
        }

        static void PrintMatrix(char[,] matrix, int row)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col]}");
            }
            Console.WriteLine();
        }
    }
}
