using System;
using System.Linq;

namespace AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pricesWithVAT = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(price => price * 1.20)
                .ToList();

            pricesWithVAT.ForEach(price => Console.WriteLine($"{price:f2}"));
        }
    }
}
