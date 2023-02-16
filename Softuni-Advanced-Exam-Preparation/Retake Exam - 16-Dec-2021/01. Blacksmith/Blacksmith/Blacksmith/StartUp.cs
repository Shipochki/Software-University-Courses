using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] inputSteal = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] inputCarbon = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> steal = new Queue<int>(inputSteal);

            Stack<int> carbon = new Stack<int>(inputCarbon);

            Dictionary<string, int> swords = new Dictionary<string, int>()
            {
                {"Gladius",70 },
                {"Shamshir",80 },
                {"Katana",90 },
                {"Sabre",110 },
                {"Broadsword",150 }
            };

            SortedDictionary<string, int> swordsCount = new SortedDictionary<string, int>()
                {
                {"Gladius",0 },
                {"Shamshir",0 },
                {"Katana",0 },
                {"Sabre",0 },
                {"Broadsword",0 }
            };

            int forgeSword = 0;

            while (steal.Count > 0 && carbon.Count > 0)
            {
                int currentSum = steal.Peek() + carbon.Peek();
                if(swords.ContainsValue(currentSum))
                {
                    steal.Dequeue();
                    carbon.Pop();
                    string name = swords.First(s => s.Value == currentSum).Key;
                    swordsCount[name]++;
                    forgeSword++;
                }
                else
                {
                    steal.Dequeue();
                    carbon.Push(carbon.Pop()+5);
                }
            }

            if(forgeSword > 0)
            {
                Console.WriteLine($"You have forged {forgeSword} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if(steal.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steal)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if(carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var sword in swordsCount)
            {
                if(sword.Value > 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
