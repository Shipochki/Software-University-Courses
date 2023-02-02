using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(inputNums.Where(n => n % 2 == 0));

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
