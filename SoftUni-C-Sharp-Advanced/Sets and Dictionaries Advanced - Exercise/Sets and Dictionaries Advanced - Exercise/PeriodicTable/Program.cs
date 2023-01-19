using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfLine = int.Parse(Console.ReadLine());

            HashSet<string> periodicTable = new HashSet<string>();

            for (int i = 0; i < numOfLine; i++)
            {
                string[] cheintmicalElements = Console.ReadLine().Split();

                foreach (var element in cheintmicalElements)
                {
                    periodicTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable.OrderBy(x => x)));
        }
    }
}
