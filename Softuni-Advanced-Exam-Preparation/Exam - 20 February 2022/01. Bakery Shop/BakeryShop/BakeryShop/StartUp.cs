using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            double[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            double[] secondLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Queue<double> water = new Queue<double>(firstLine);

            Stack<double> flour = new Stack<double>(secondLine);

            SortedDictionary<string, int> countProduct = new SortedDictionary<string, int>()
            {
                {"Croissant", 0},
                {"Muffin", 0},
                {"Baguette",0 },
                {"Bagel",0 }
            };

            while (water.Count != 0 && flour.Count != 0)
            {
                double currentSum = water.Peek() + flour.Peek();
                if (currentSum * 0.4 == water.Peek() && currentSum * 0.6 == flour.Peek())
                {
                    flour.Pop();
                    countProduct["Muffin"]++;
                }
                else if (currentSum * 0.3 == water.Peek() && currentSum * 0.7 == flour.Peek())
                {
                    flour.Pop();
                    countProduct["Baguette"]++;
                }
                else if(currentSum * 0.2 == water.Peek() && currentSum * 0.8 == flour.Peek())
                {
                    flour.Pop();
                    countProduct["Bagel"]++;
                }
                else if (water.Peek() == flour.Peek())
                {
                    flour.Pop();
                    countProduct["Croissant"]++;
                }
                else
                {
                    double lastFlour = flour.Pop();
                    flour.Push(lastFlour -= water.Dequeue());
                    countProduct["Croissant"]++;
                    continue;
                }
                water.Dequeue();
            }

            foreach (var product in countProduct.OrderByDescending(c => c.Value))
            {
                if(product.Value != 0)
                    Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if(water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }

            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }
    }
}
