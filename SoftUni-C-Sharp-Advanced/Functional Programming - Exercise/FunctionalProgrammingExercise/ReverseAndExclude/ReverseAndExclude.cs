using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    internal class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int number = int.Parse(Console.ReadLine());

            Predicate<int> isDisible = num => num % number != 0;

            foreach (var item in nums)
            {
                if(isDisible(item))
                    Console.Write($"{item} ");
            }
        }
    }
}
