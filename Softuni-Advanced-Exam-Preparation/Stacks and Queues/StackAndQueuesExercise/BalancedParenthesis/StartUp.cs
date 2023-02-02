using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if(input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> firstHalf = new Stack<char>();
            Queue<char> secondHalf = new Queue<char>();

            foreach(char c in input)
            {
                if(c == '(' || c == '[' || c == '{') 
                { 
                    firstHalf.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    secondHalf.Enqueue(c);
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            if(firstHalf.Count != secondHalf.Count)
            {
                Console.WriteLine("NO");
                return;
            }

            bool isYes = false;

            for (int i = 0; i < firstHalf.Count; i++)
            {
                if(firstHalf.Peek() == '(' && secondHalf.Peek() == ')'
                    || firstHalf.Peek() == '[' && secondHalf.Peek() == ']'
                    || firstHalf.Peek() == '{' && secondHalf.Peek() == '}')
                {
                    firstHalf.Pop();
                    secondHalf.Dequeue();
                    isYes = true;
                }
            }

            if(isYes)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
