using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> bigBox = new Stack<int>(clothes.Reverse());

            int capacityOfRack = int.Parse(Console.ReadLine());
            int rackCount = 1;
            int sum = 0;

            while(bigBox.Count > 0)
            {
                sum += bigBox.Peek();

                if(sum <= capacityOfRack)
                {
                    bigBox.Pop();
                }
                else
                {
                    rackCount++;
                    sum = 0;
                }
            }

            Console.WriteLine(rackCount);
        }
    }
}
