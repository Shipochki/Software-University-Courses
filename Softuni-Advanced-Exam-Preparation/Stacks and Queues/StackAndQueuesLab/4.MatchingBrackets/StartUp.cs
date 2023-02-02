using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingBrackets
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string splitedInput = Console.ReadLine();
            Stack<int> bracketsIndexes = new Stack<int>();
            int i = 0;

            foreach (var c in splitedInput)
            {
                if (c == '(')
                {
                    bracketsIndexes.Push(i);
                }
                else if (c == ')')
                {
                    for (int j = bracketsIndexes.Pop(); j <= i; j++)
                    {
                        Console.Write(splitedInput[j]);
                    }
                    Console.WriteLine();
                }
                i++;
            }
        }
    }
}
