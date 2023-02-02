using System;
using System.Collections.Generic;

namespace TrafficJam
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<string> traffic = new Queue<string>();
            int numOfPassesCars = int.Parse(Console.ReadLine());
            int counterPassesCars = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "end")
                {
                    break;
                }

                if(input == "green")
                {
                    int currentLength = traffic.Count;
                    for (int i = 0; i < currentLength; i++)
                    {
                        if(i == numOfPassesCars)
                        {
                            break;
                        }
                        Console.WriteLine($"{traffic.Dequeue()} passed!");

                        counterPassesCars++;
                    }
                }
                else
                {
                    traffic.Enqueue(input);
                }
            }

            Console.WriteLine($"{counterPassesCars} cars passed the crossroads.");
        }
    }
}
