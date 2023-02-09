using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpAMole
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            Dictionary<int, int> specialPlace = new Dictionary<int, int>();
            int[] mole = new int[2];
            int points = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == 'S')
                    {
                        specialPlace.Add(row, col);
                    }
                    else if (line[col] == 'M')
                    {
                        mole[0] = row;
                        mole[1] = col;
                        matrix[row, col] = '-';
                    }
                }
            }

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "End")
                {
                    break;
                }

                bool tryToEscape = false;

                if (comand == "up")
                {
                    if (mole[0] - 1 < 0)
                    {
                        tryToEscape = true;
                    }
                    else
                    {
                        mole[0]--;
                    }
                }
                else if (comand == "down")
                {
                    if (mole[0] + 1 >= matrix.GetLength(0))
                    {
                        tryToEscape = true;
                    }
                    else
                    {
                        mole[0]++;
                    }
                }
                else if (comand == "left")
                {
                    if (mole[1] - 1 < 0)
                    {
                        tryToEscape = true;
                    }
                    else
                    {
                        mole[1]--;
                    }
                }
                else if (comand == "right")
                {
                    if (mole[1] + 1 >= matrix.GetLength(1))
                    {
                        tryToEscape = true;
                    }
                    else
                    {
                        mole[1]++;
                    }
                }

                if (tryToEscape)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                }
                else
                {
                    if (matrix[mole[0], mole[1]] == 'S')
                    {
                        specialPlace.Remove(mole[0]);
                        matrix[mole[0], mole[1]] = '-';
                        mole[0] = specialPlace.First().Key;
                        mole[1] = specialPlace.First().Value;
                        specialPlace.Remove(mole[0]);
                        points -= 3;
                    }
                    else if (char.IsDigit(matrix[mole[0], mole[1]]))
                    {
                        points += int.Parse(matrix[mole[0], mole[1]].ToString());
                    }
                }

                if(points >= 25)
                {
                    break;
                }

                matrix[mole[0], mole[1]] = '-';

            }

            matrix[mole[0], mole[1]] = 'M';

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}