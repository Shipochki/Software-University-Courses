using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            StringBuilder sb = new StringBuilder();
            int numOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfLines; i++)
            {
                string[] comands = Console.ReadLine()
                    .Split()
                    .ToArray();

                string comand = comands[0];

                if(comand == "1")
                {
                    stack.Push(sb.ToString());
                    sb.Append(comands[1]);
                }
                else if(comand == "2")
                {
                    stack.Push(sb.ToString());
                    int length = int.Parse(comands[1]);
                    sb.Remove(sb.Length - length, length);
                }
                else if(comand == "3")
                {
                    int index = int.Parse(comands[1]);
                    Console.WriteLine(sb[index - 1]);
                }
                else if(comand == "4")
                {
                    sb = new StringBuilder(stack.Pop());
                }
            }
        }
    }
}
