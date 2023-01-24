using System;
using System.Linq;

namespace Action_Point
{
    internal class ActionPoint
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<string> print = text => Console.WriteLine(text);

            names.ForEach(print);
        }
    }
}
