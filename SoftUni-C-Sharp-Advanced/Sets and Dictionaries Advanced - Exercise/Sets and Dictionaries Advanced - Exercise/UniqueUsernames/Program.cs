using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfLine = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < numOfLine; i++)
            {
                string username = Console.ReadLine();

                usernames.Add(username);
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username.ToString());
            }
        }
    }
}
