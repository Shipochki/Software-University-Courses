using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            Stack<string> historyText = new Stack<string>();

            for (int i = 0; i < numOfLines; i++)
            {
                var cmd = Console.ReadLine().Split();

                if (cmd[0] == "1")
                {
                    historyText.Push(text.ToString());

                    text.Append(cmd[1]);
                }
                else if (cmd[0] == "2")
                {
                    historyText.Push(text.ToString());

                    int count = int.Parse(cmd[1]);

                    text.Remove(text.Length - count, count);
                }
                else if (cmd[0] == "3")
                {
                    int index = int.Parse(cmd[1]);

                    Console.WriteLine(text[index - 1]);
                }
                else if (cmd[0] == "4")
                {
                    text = new StringBuilder(historyText.Pop());
                }
            }
        }
    }
}
