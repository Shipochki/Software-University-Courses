using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            List<char> woods = new List<char>();
            int collectedWoods = 0;
            int countWoods = 0;
            int[] beaver = new int[2];
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'B')
                    {
                        beaver[0] = row;
                        beaver[1] = col;
                    }
                    else if (char.IsLetter(input[col]) && char.IsLower(input[col]))
                    {
                        countWoods++;
                    }
                }
            }

            string comand = Console.ReadLine();

            while (comand != "end" && countWoods != collectedWoods)
            {
                bool isOut = false;
                if (comand == "up")
                {
                    if (beaver[0] - 1 < 0)
                    {
                        isOut = true;
                    }
                    else
                    {
                        matrix[beaver[0], beaver[1]] = '-';
                        beaver[0]--;
                        char current = matrix[beaver[0], beaver[1]];
                        if (char.IsLetter(current) && char.IsLower(current))
                        {
                            woods.Add(current);
                            collectedWoods++;
                        }
                        else if (current == 'F')
                        {
                            matrix[beaver[0], beaver[1]] = '-';
                            beaver[0] = size - 1;
                            char currentAfterF = matrix[beaver[0], beaver[1]];
                            if (char.IsLetter(currentAfterF) && char.IsLower(currentAfterF))
                            {
                                woods.Add(currentAfterF);
                                collectedWoods++;
                            }
                        }
                        matrix[beaver[0], beaver[1]] = 'B';
                    }
                }
                else if (comand == "down")
                {
                    if (beaver[0] + 1 >= size)
                    {
                        isOut = true;
                    }
                    else
                    {
                        matrix[beaver[0], beaver[1]] = '-';
                        beaver[0]++;
                        char current = matrix[beaver[0], beaver[1]];
                        if (char.IsLetter(current) && char.IsLower(current))
                        {
                            woods.Add(current);
                            collectedWoods++;
                        }
                        else if (current == 'F')
                        {
                            matrix[beaver[0], beaver[1]] = '-';
                            beaver[0] = 0;
                            char currentAfterF = matrix[beaver[0], beaver[1]];
                            if (char.IsLetter(currentAfterF) && char.IsLower(currentAfterF))
                            {
                                woods.Add(currentAfterF);
                                collectedWoods++;
                            }
                        }
                        matrix[beaver[0], beaver[1]] = 'B';
                    }
                }
                else if(comand == "left")
                {
                    if (beaver[1] - 1 < 0)
                    {
                        isOut = true;
                    }
                    else
                    {
                        matrix[beaver[0], beaver[1]] = '-';
                        beaver[1]--;
                        char current = matrix[beaver[0], beaver[1]];
                        if (char.IsLetter(current) && char.IsLower(current))
                        {
                            woods.Add(current);
                            collectedWoods++;
                        }
                        else if (current == 'F')
                        {
                            matrix[beaver[0], beaver[1]] = '-';
                            beaver[1] = 0;
                            char currentAfterF = matrix[beaver[0], beaver[1]];
                            if (char.IsLetter(currentAfterF) && char.IsLower(currentAfterF))
                            {
                                woods.Add(currentAfterF);
                                collectedWoods++;
                            }
                        }
                        matrix[beaver[0], beaver[1]] = 'B';
                    }
                }
                else if (comand == "right")
                {
                    if (beaver[1] + 1 >= size)
                    {
                        isOut = true;
                    }
                    else
                    {
                        matrix[beaver[0], beaver[1]] = '-';
                        beaver[1]++;
                        char current = matrix[beaver[0], beaver[1]];
                        if (char.IsLetter(current) && char.IsLower(current))
                        {
                            woods.Add(current);
                            collectedWoods++;
                        }
                        else if (current == 'F')
                        {
                            matrix[beaver[0], beaver[1]] = '-';
                            beaver[1] = 0;
                            char currentAfterF = matrix[beaver[0], beaver[1]];
                            if (char.IsLetter(currentAfterF) && char.IsLower(currentAfterF))
                            {
                                woods.Add(currentAfterF);
                                collectedWoods++;
                            }
                        }
                        matrix[beaver[0], beaver[1]] = 'B';
                    }
                }

                if(isOut && woods.Count != 0)
                {
                    woods.RemoveAt(woods.Count - 1);
                }

                comand = Console.ReadLine();
            }

            if(countWoods == collectedWoods)
            {
                Console.WriteLine($"The Beaver successfully collect {woods.Count} wood branches: {string.Join(", ", woods)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countWoods - collectedWoods} branches left.");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
