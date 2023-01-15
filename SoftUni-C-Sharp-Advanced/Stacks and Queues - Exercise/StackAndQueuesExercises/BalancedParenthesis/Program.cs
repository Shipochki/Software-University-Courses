using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            int length = input.Length / 2;

            Stack<string> firstHalf = new Stack<string>();

            Queue<string> secondHalf = new Queue<string>();

            for (int i = 0; i < length; i++)
            {
                secondHalf.Enqueue(input[i].ToString());
            }

            for (int i = length; i <= input.Length - 1; i++)
            {
                firstHalf.Push(input[i].ToString());

            }

            if (secondHalf.Count == 0 || firstHalf.Count == 0)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < length; i++)
            {
                
                if (secondHalf.Peek() == "(" && firstHalf.Peek() != ")" || 
                    secondHalf.Peek() == "[" && firstHalf.Peek() != "]" || 
                    secondHalf.Peek() == "{" && firstHalf.Peek() != "}")
                {
                    Console.WriteLine("NO");
                    return;
                }
                else
                {
                    firstHalf.Pop();
                    secondHalf.Dequeue();
                }
            }

            Console.WriteLine("YES");
        }
    }
}
