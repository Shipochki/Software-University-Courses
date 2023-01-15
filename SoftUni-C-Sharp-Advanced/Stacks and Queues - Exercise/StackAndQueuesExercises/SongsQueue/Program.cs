using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (songs.Count > 0)
            {
                string cmd = Console.ReadLine();

                if (cmd == "Play")
                {
                    songs.Dequeue();
                }
                else if (cmd.Contains("Add"))
                {
                    string songName = cmd.Substring(4);

                    if (!songs.Contains(songName))
                    {
                        songs.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }
                else if (cmd == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
