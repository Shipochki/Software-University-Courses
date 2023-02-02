using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] inputOrders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(inputOrders);

            Console.WriteLine(orders.Max());

            while (orders.Count > 0)
            {
                if (foodQuantity - orders.Peek() >= 0)
                {
                    foodQuantity -= orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
