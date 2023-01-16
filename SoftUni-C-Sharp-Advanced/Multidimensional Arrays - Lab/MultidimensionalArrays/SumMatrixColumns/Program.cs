﻿using System;
using System.Linq;


namespace SumMatrixElements
{
    internal class Program
    {
        static void Main()
        {
            int[] rowsAndColm = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowsAndColm[0];
            int cols = rowsAndColm[1];

            long[] columsSum = new long[cols];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                    columsSum[col] += nums[col];
                }
            }

            foreach (var colum in columsSum)
            {
                Console.WriteLine(colum);
            }
        }
    }
}

