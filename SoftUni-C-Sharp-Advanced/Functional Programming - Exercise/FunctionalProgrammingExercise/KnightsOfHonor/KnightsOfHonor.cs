using System;
using System.Linq;

namespace KnightsOfHonor
{
    internal class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            var namesOfKnights = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<string> print = name => Console.WriteLine($"Sir {name}");

            namesOfKnights.ForEach(print);
        }
    }
}
