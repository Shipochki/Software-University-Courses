using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] colorAndItems = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string[] items = colorAndItems[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                string color = colorAndItems[0];
                

                if (!wardrobe.ContainsKey(color))
                    wardrobe.Add(color, new Dictionary<string, int>());

                for (int j = 0; j < items.Length; j++)
                {
                    string item = items[j];
                    if (!wardrobe[color].ContainsKey(item))
                        wardrobe[color].Add(item, 0);

                    wardrobe[color][item]++;
                }
            }

            string[] order = Console.ReadLine().Split();
            string colorOrder = order[0];
            string itemOrder = order[1];

            bool colorIsFound = false;
            bool itemIsFound = false;

            foreach (var color in wardrobe)
            {
                if (color.Key == colorOrder)
                {
                    colorIsFound = true;
                }

                Console.WriteLine($"{color.Key} clothes:");
                foreach (var item in color.Value)
                {
                    if (item.Key == itemOrder)
                    {
                        itemIsFound = true;
                    }

                    if (colorIsFound && itemIsFound)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                        colorIsFound = false;
                        itemIsFound = false;
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }

                }
            }
        }
    }
}
