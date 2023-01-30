using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCount
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var boxList = new List<Box<double>>();

            int numOfItems = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfItems; i++)
            {
                var input = double.Parse(Console.ReadLine());
                var box = new Box<double>(input);
                boxList.Add(box);
            }

            var item = double.Parse(Console.ReadLine());

            int count = 0;

            foreach (var box in boxList)
            {
                if (box.Item > item)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
