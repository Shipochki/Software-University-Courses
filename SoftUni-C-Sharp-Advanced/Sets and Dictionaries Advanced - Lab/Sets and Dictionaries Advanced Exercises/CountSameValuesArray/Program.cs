using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> countNums = new Dictionary<double, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (countNums.ContainsKey(nums[i]))
                {
                    countNums[nums[i]]++;
                }
                else
                {
                    countNums.Add(nums[i], 1);
                }
            }

            foreach (var num in countNums)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
