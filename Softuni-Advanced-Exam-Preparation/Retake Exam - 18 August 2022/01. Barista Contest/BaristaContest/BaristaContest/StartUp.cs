using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] inputCoffeeData = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[] inputMilkData = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> coffee = new Queue<int>(inputCoffeeData);

            Stack<int> milk = new Stack<int>(inputMilkData);

            Dictionary<string, int> coffeeTypes = new Dictionary<string, int>()
            {
                {"Cortado",50 },
                {"Espresso", 75 },
                {"Capuccino", 100 },
                {"Americano", 150 },
                {"Latte", 200 }
            };

            Dictionary<string, int> coffeeCount = new Dictionary<string, int>()
            {
                {"Cortado",0 },
                {"Espresso", 0 },
                {"Capuccino", 0 },
                {"Americano", 0 },
                {"Latte", 0 }
            };

            while (true)
            {
                if(coffee.Count == 0 || milk.Count == 0)
                {
                    break;
                }

                bool isCreated = false;

                foreach (var type in coffeeTypes)
                {
                    if(coffee.Peek() + milk.Peek() == type.Value)
                    {
                        isCreated= true;
                        coffeeCount[type.Key]++;
                    }
                }

                coffee.Dequeue();

                if(isCreated)
                {
                    milk.Pop();
                }
                else
                {
                    milk.Push(milk.Pop() - 5);
                }
            }

            if(coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if(coffee.Count > 0)
            {
                Console.WriteLine($"Coffee left: { string.Join(",", coffee)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milk.Count > 0)
            {
                Console.WriteLine($"Milk left: {string.Join(",", milk)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }

            foreach (var count in coffeeCount
                .OrderBy(c => c.Value)
                .ThenByDescending(c => c.Key)
                .Where(c => c.Value != 0))
            {
                Console.WriteLine($"{count.Key}: {count.Value}");
            }
        }
    }
}