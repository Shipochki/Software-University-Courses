using System;
using System.Collections.Generic;
using System.Linq;

namespace Armory
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int[] officer = new int[2];
            Dictionary<int, int> mirrors = new Dictionary<int, int>();

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'A')
                    {
                        officer[0] = row;
                        officer[1] = col;
                    }
                    else if (input[col] == 'M')
                    {
                        mirrors.Add(row, col);
                    }
                }
            }

            int coins = 0;
            bool isEnd = false;

            while (coins < 65)
            {
                isEnd = false;
                string command = Console.ReadLine();
                matrix[officer[0], officer[1]] = '-';

                if (command == "up")
                {
                    if (officer[0] - 1 >= 0)
                    {
                        officer[0]--;
                    }
                    else
                    {
                        isEnd = true;
                    }
                }
                else if (command == "down")
                {
                    if (officer[0] + 1 < size)
                    {
                        officer[0]++;
                    }
                    else
                    {
                        isEnd = true;
                    }
                }
                else if (command == "left")
                {
                    if (officer[1] - 1 >= 0)
                    {
                        officer[1]--;
                    }
                    else
                    {
                        isEnd = true;
                    }
                }
                else if (command == "right")
                {
                    if (officer[1] + 1 < size)
                    {
                        officer[1]++;
                    }
                    else
                    {
                        isEnd = true;
                    }
                }

                if (isEnd)
                {
                    break;
                }

                if (char.IsDigit(matrix[officer[0], officer[1]]))
                {
                    int digit = int.Parse(matrix[officer[0], officer[1]].ToString());
                    coins += digit;
                    matrix[officer[0], officer[1]] = '-';
                }
                else if (matrix[officer[0], officer[1]] == 'M')
                {
                    mirrors.Remove(officer[0]);
                    int newRow = mirrors.Last().Key;
                    int newCol = mirrors.Last().Value;
                    mirrors.Remove(newRow);
                    matrix[officer[0], officer[1]] = '-';
                    officer[0] = newRow;
                    officer[1] = newCol;
                    matrix[officer[0], officer[1]] = '-';
                }

                matrix[officer[0], officer[1]] = 'A';

            }

            if (isEnd)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {coins} gold coins.");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
