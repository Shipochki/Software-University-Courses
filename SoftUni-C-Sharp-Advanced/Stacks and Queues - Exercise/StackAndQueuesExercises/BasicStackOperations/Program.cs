using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nsx = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < nsx[0]; i++)
            {
                stack.Push(nums[i]);
            }

            for (int i = 0; i < nsx[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(nsx[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int smallest = int.MaxValue;
                foreach (var item in stack)
                {
                    int current = item;
                    if (current < smallest)
                    {
                        smallest = current;
                    }
                }

                Console.WriteLine(smallest);
            }
        }
    }
}
