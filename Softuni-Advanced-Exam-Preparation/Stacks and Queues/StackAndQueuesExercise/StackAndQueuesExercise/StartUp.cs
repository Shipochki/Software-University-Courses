using System;
using System.Collections.Generic;
using System.Linq;

namespace StackAndQueuesExercise
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

            Stack<int> stack = new Stack<int>(nums.Take(n));

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
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
