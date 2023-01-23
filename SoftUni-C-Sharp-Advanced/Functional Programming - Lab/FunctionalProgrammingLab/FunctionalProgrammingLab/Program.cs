using System;
using System.Linq;

namespace FunctionalProgrammingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stringNums = input.Split(", ");
            var nums = stringNums.Select(x => int.Parse(x));
            var evenNums = nums.Where(x => x % 2 == 0);
            var sortedEvenNums = evenNums.OrderBy(x => x);

            Console.WriteLine(string.Join(", ", sortedEvenNums));
        }
    }
}
