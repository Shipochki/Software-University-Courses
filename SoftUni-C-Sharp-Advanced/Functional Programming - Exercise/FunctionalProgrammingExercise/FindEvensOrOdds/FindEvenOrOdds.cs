using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    internal class FindEvenOrOdds
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int end = range[1];

            string comand = Console.ReadLine();

            Predicate<int> filter = IsEvenOrOdd(comand);

            List<int> filteredNums = FilterNums(filter, start, end);

            PrintNums(filteredNums);
        }

        public static Predicate<int> IsEvenOrOdd(string comand)
        {
            if (comand == "even")
                return x => x % 2 == 0;
            else if (comand == "odd")
                return x => x % 2 != 0;
            else
                throw new ArgumentException($"Invalid comand: {comand}");
        }

        private static List<int> FilterNums(Predicate<int> filter, int start, int end)
        {
            List<int> filteredNums = new List<int>();
            for (int num = start; num <= end; num++)
            {
                if(filter(num))
                    filteredNums.Add(num);
            }

            return filteredNums;
        }

        private static void PrintNums(List<int> filteredNums)
        {
            Console.WriteLine(string.Join(" ", filteredNums));
        }
    }
}
