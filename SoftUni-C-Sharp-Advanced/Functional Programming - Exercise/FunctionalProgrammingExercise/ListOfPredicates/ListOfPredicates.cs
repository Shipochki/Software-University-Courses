using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    internal class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Predicate<int> isDivisible = null;

            for (int i = 1; i <= range; i++)
            {
                int count = 0;
                foreach (var item in dividers)
                {
                    isDivisible = num => num % item == 0;
                    if(isDivisible(i))
                        count++;
                }

                if(count == dividers.Count)
                    Console.Write($"{i} ");
            }
        }
    }
}
