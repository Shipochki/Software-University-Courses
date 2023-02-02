using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] comands = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = comands[0];
            int s = comands[1];
            int x = comands[2];

            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            if (n - s <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            Queue<int> stack = new Queue<int>(nums.Take(n));

            for (int i = 0; i < s; i++)
            {
                stack.Dequeue();
            }

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
