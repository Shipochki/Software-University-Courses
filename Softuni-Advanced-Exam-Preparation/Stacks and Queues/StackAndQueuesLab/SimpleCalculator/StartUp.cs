using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] splitedInput = Console.ReadLine()
                .Split()
                .ToArray();

            Stack<string> nums = new Stack<string>(splitedInput.Reverse());

            while (nums.Count > 1) 
            {
                string cuurentLast = nums.Pop();
                if(nums.Peek() == "+")
                {
                    nums.Pop();
                    string last = nums.Pop();
                    nums.Push((int.Parse(cuurentLast) + int.Parse(last)).ToString());
                }
                else if (nums.Peek() == "-")
                {
                    nums.Pop();
                    string last = nums.Pop();
                    nums.Push((int.Parse(cuurentLast) - int.Parse(last)).ToString());
                }
            }

            Console.WriteLine(nums.Peek());
        }
    }
}
