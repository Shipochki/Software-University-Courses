using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] firstLineNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> nums = new Stack<int>(firstLineNums);

            while (true)
            {
                string[] inputComand = Console.ReadLine()
                    .Split()
                    .ToArray();

                string comand = inputComand[0].ToLower();

                if (comand == "end")
                {
                    break;
                }

                int firstNum = int.Parse(inputComand[1]);

                if (comand == "add")
                {
                    int secondNum = int.Parse(inputComand[2]);
                    nums.Push(firstNum);
                    nums.Push(secondNum);
                }
                else if (comand == "remove" && nums.Count > firstNum )
                {
                    for (int i = 0; i < firstNum; i++)
                    {
                        nums.Pop();
                    }
                }
            }

            Console.WriteLine($"Sum: {nums.Sum()}");
        }
    }
}
