using System;
using System.Linq;
using System.Collections.Generic;

namespace WallDestroyer
{
    public class StartUp
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = new char[size, size];
            int[] vanko = new int[2];
            char hole = '*';
            int countRodes = 0;
            int countHoles = 1;
            bool isElectriced = false;

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    wall[row, col] = input[col];
                    if (input[col] == 'V')
                    {
                        vanko[0] = row;
                        vanko[1] = col;
                        wall[row, col] = hole;
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

                if (comand == "up")
                {
                    if (vanko[0] > 0)
                    {
                        if (wall[vanko[0] - 1, vanko[1]] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            countRodes++;
                            continue;
                        }
                        vanko[0]--;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (comand == "down")
                {
                    if (vanko[0] < size)
                    {
                        if (wall[vanko[0] + 1, vanko[1]] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            countRodes++;
                            continue;
                        }
                        vanko[0]++;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (comand == "right")
                {
                    if (vanko[1] < size)
                    {
                        if (wall[vanko[0], vanko[1] + 1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            countRodes++;
                            continue;
                        }
                        vanko[1]++;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (comand == "left")
                {
                    if (vanko[1] > 0)
                    {
                        if (wall[vanko[0], vanko[1] - 1] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            countRodes++;
                            continue;
                        }
                        vanko[1]--;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (wall[vanko[0], vanko[1]] == 'C')
                {
                    isElectriced = true;
                    wall[vanko[0], vanko[1]] = 'E';
                    countHoles++;
                    break;
                }

                if (wall[vanko[0], vanko[1]] == hole)
                {
                    Console.WriteLine($"The wall is already destroyed at position [{vanko[0]}, {vanko[1]}]!");
                }
                else
                {
                    wall[vanko[0], vanko[1]] = hole;
                    countHoles++;
                }
            }

            if (isElectriced)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
            }
            else
            {
                wall[vanko[0], vanko[1]] = 'V';
                Console.WriteLine($"Vanko managed to make {countHoles} hole(s) and he hit only {countRodes} rod(s).");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}