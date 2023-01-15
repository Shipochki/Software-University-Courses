using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numOfLines; i++)
            {
                var cmd = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                if (cmd[0] == 1)
                {
                    stack.Push(cmd[1]);
                }
                else if (cmd[0] == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }

                }
                else if (cmd[0] == 3)
                {
                    if (stack.Count > 0)
                    {
                        int max = int.MinValue;
                        foreach (var item in stack)
                        {
                            if (item > max)
                            {
                                max = item;
                            }
                        }
                        Console.WriteLine(max);
                    }
                }
                else if (cmd[0] == 4)
                {
                    if (stack.Count > 0)
                    {
                        int min = int.MaxValue;
                        foreach (var item in stack)
                        {
                            if (item < min)
                            {
                                min = item;
                            }
                        }
                        Console.WriteLine(min);
                    }
                }

            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
