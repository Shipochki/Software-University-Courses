using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clothesValue = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var capacityOfRack = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(clothesValue);

            int sum = 0;

            int countRacks = 0;

            if (clothes.Sum() != 0)
            {
                countRacks = 1;
            }

            while (clothes.Count > 0)
            {
                if (sum <= capacityOfRack)
                {                    
                    sum += clothes.Pop();
                }
                else if (sum > capacityOfRack)
                {
                    sum -= capacityOfRack;
                    countRacks++;
                }

            }

            if (sum != 0)
            {
                countRacks++;
            }

            Console.WriteLine(countRacks);
        }
    }
}
