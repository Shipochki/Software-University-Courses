using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    internal class PredicateForNames
    {
        static void Main(string[] args)
        {
            int namesLength = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Predicate<string> isEnoughLenght = name => name.Count() <= namesLength;

            foreach (var name in names)
            {
                if (isEnoughLenght(name))
                    Console.WriteLine(name);
            }
        }
    }
}
