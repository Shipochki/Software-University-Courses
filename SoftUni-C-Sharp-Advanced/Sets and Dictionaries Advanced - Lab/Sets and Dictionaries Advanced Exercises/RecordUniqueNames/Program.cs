using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfNames = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < numOfNames; i++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }

            foreach (var item in names)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
