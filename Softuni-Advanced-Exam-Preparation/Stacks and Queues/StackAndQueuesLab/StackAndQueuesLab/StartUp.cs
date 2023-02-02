using System;
using System.Collections.Generic;

namespace StackAndQueuesLab
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            Stack<string> reversedString = new Stack<string>();
            foreach (var c in inputString) 
            {
                reversedString.Push(c.ToString());
            }
            Console.WriteLine(string.Join("", reversedString));
        }
    }
}
