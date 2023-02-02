using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumMinimumElement
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int numOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfLines; i++)
            {
                string comand = Console.ReadLine();

                if (comand.StartsWith("1"))
                {
                    int num = int.Parse(comand.Split()[1]);
                    stack.Push(num);
                }
                
                if(stack.Count <= 0)
                {
                    continue;
                }
                else if(comand == "2")
                {
                    stack.Pop();
                }
                else if(comand == "3")
                {
                    Console.WriteLine(stack.Max());
                }
                else if(comand == "4")
                {
                    Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
