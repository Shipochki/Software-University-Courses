using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    internal class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> findMinNum = num => num.Min();
            Func<string, int> parses = text => int.Parse(text);
            Action<string> print = num => Console.WriteLine(num);

            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parses)
                .ToList();

            int minNum = findMinNum(nums);

            print(minNum.ToString());
        }
    }
}
