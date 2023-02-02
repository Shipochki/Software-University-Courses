using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputSongs = Console.ReadLine()
                .Split(", ")
                .ToArray();

            Queue<string> songsQueue = new Queue<string>(inputSongs);

            while (songsQueue.Count > 0)
            {
                string command = Console.ReadLine();

                if (command.StartsWith("Add"))
                {
                    string song = command.Substring(4);
                    if (songsQueue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                        continue;
                    }

                    songsQueue.Enqueue(song);
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
                else if (command == "Play")
                {
                    songsQueue.Dequeue();
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
