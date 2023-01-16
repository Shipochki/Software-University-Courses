using System;
using System.Linq;

namespace JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int square = int.Parse(Console.ReadLine());

            int[][] matrix = new int[square][];

            for (int row = 0; row < square; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                string comand = input[0];

                if (comand == "END")
                {
                    break;
                }
                else if (comand == "Add")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int value = int.Parse(input[3]);

                    if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (comand == "Subtract")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int value = int.Parse(input[3]);

                    if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

            foreach (var row in matrix)
            {
                foreach (var col in row)
                {
                    Console.Write($"{col} ");
                }
                Console.WriteLine();
            }
        }
    }
}
