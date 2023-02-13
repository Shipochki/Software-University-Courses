using System;
using System.Linq;
using System.Collections.Generic;

namespace TilesMaster
{
    public class StartUp
    {
        public static void Main()
        {
            int[] stackInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] queInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> white = new Stack<int>(stackInput);

            Queue<int> grey = new Queue<int>(queInput);

            Dictionary<string, int> locataions = new Dictionary<string, int>()
            {
                {"Sink", 40 },
                {"Oven", 50 },
                {"Countertop", 60 },
                {"Wall", 70 }
            };

            SortedDictionary<string, int> locationsCount = new SortedDictionary<string, int>()
            {
                {"Sink", 0 },
                {"Oven", 0 },
                {"Countertop", 0 },
                {"Wall", 0 },
                {"Floor", 0 }
            };

            while (true)
            {
                if (white.Count == 0 || grey.Count == 0)
                {
                    break;
                }

                if(white.Peek() == grey.Peek())
                {
                    int currentSum = white.Peek() + grey.Peek();

                    if (locataions.Values.Contains(currentSum))
                    {
                        foreach (var item in locataions)
                        {
                            if (item.Value == currentSum)
                            {
                                locationsCount[item.Key]++;
                                break;
                            }
                        }
                    }
                    else
                    {
                        locationsCount["Floor"]++;
                    }

                    white.Pop();
                    grey.Dequeue();
                }
                else
                {
                    white.Push(white.Pop() / 2);
                    grey.Enqueue(grey.Dequeue());
                }
            }

            if(white.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", white)}");
            }


            if (grey.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grey)}");
            }

            foreach (var item in locationsCount.OrderByDescending(i => i.Value))
            {
                if(item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}