using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Queue<string> players = new Queue<string>(names);
            int index = int.Parse(Console.ReadLine());
            int currentIndex = 1;

            while (players.Count > 1)
            {
                if(currentIndex == index)
                {
                    Console.WriteLine($"Removed {players.Dequeue()}");
                    currentIndex = 0;
                }
                else
                {
                    players.Enqueue(players.Dequeue());
                }

                currentIndex++;
            }

            Console.WriteLine($"Last is {players.Peek()}");
        }
    }
}
