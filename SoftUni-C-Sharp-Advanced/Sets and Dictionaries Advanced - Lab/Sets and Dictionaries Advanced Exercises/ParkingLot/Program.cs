using System;
using System.Collections.Generic;

namespace ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "END")
                {
                    break;
                }
                else if (input[0] == "IN")
                {
                    carNumbers.Add(input[1]);
                }
                else if (input[0] == "OUT")
                {
                    carNumbers.Remove(input[1]);
                }
            }

            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var number in carNumbers)
                {
                    Console.WriteLine(number.ToString());
                }
            }
        }
    }
}
