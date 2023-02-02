using System;
using System.Collections.Generic;

namespace Supermarket
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "End")
                {
                    break;
                }

                if(input == "Paid")
                {
                    foreach(var customer in customers)
                    {
                        Console.WriteLine(customer);
                    }
                    customers.Clear();
                }
                else
                {
                    customers.Enqueue(input);
                }
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
