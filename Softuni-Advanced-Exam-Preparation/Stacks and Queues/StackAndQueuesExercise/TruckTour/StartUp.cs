using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int[]> pumps = new Queue<int[]>();
            int numPumps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numPumps; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(nums);
            }

            int counter = 0;

            while (true)
            {
                bool isSmallest = true;
                int[] currentPump = pumps.Dequeue();
                if (currentPump[0] < currentPump[1])
                {
                    isSmallest = false;
                }

                if(isSmallest)
                {
                    break;
                }

                counter++;
            }

            Console.WriteLine(counter);
        }
    }
}
