using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    internal class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                Predicate<string> predicate = GetPredicate(command);

                if (command.StartsWith("Double"))
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        string name = names[i];
                        if (predicate(name))
                        {
                            names.Insert(i + 1, name);
                            i++;
                        }
                    } 
                }
                else if (command.StartsWith("Remove"))
                {
                    names.RemoveAll(predicate);
                }

                command = Console.ReadLine();
            }

            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string comand)
        {
            string type = comand.Split()[1];
            string input = comand.Split()[2];

            Predicate<string> predicate = null;
            if (type == "StartsWith")
                predicate = name => name.StartsWith(input);
            else if (type == "EndsWith")
                predicate = name => name.EndsWith(input);
            else if (type == "Length")
                predicate = name => name.Length == int.Parse(input);

            return predicate;
        }
    }
}
