using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            ListBoxes<int> boxes = new ListBoxes<int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                boxes.Add(box);
            }

            int[] indexses = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = indexses[0];
            int secondIndex = indexses[1];

            boxes.Swap(firstIndex, secondIndex);

            foreach (var box in boxes.Boxes)
            {
                Console.WriteLine($"{box.Data.GetType()}: {box.Data}");
            }
        }
    }
}
