using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicQueueOperations
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

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < nsx[0]; i++)
            {
                queue.Enqueue(nums[i]);
            }

            for (int i = 0; i < nsx[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(nsx[2]))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int smallest = int.MaxValue;
                foreach (var item in queue)
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
