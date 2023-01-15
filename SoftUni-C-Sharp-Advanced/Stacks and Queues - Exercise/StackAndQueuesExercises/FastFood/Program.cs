using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            var orders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ordersForDay = new Queue<int>(orders);

            int biggestOrder = 0;
            
            foreach (var order in ordersForDay)
            {
                if (order > biggestOrder)
                {
                    biggestOrder = order;
                }
            }

            while (ordersForDay.Count > 0)
            {
                if (ordersForDay.Peek() <= quantityOfFood)
                {
                    quantityOfFood -= ordersForDay.Dequeue();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(biggestOrder);

            if (ordersForDay.Count > 0)
            {
                Console.Write("Orders left: ");
                Console.WriteLine(string.Join(" ", ordersForDay));    
            }
            else
            {
                Console.WriteLine("Orders complete");
            }


        }
    }
}
