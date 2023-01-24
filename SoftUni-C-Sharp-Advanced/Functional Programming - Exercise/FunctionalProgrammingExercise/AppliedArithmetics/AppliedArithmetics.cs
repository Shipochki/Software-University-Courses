using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace AppliedArithmetics
{
    internal class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, List<int>> add = list => list.Select(num => num += 1).ToList();
            Func<List<int>, List<int>> multiply = list => list.Select(num => num *= 2).ToList();
            Func<List<int>, List<int>> subtract = list => list.Select(num => num -= 1).ToList();
            Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "end")
                    break;

                if (comand == "add")
                    nums = add(nums);
                else if (comand == "multiply")
                    nums = multiply(nums);
                else if (comand == "subtract")
                    nums = subtract(nums);
                else if (comand == "print")
                    print(nums);
            }
        }

    }
}
