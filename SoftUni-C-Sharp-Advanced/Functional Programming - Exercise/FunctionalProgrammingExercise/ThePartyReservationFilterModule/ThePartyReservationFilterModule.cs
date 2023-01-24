using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    internal class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            List<string> filtred = new List<string>(people);

            string comand = Console.ReadLine();
            while (comand != "Print")
            {
                Predicate<string> predicate = GetPredicate(comand);

                if (comand.Split(";")[0] == "Add filter")
                {
                    filtred.RemoveAll(predicate);
                }
                else if(comand.Split(";")[0] == "Remove filter")
                {
                    foreach (var item in people)
                    {
                        if (predicate(item))
                            filtred.Insert(people.IndexOf(item), item);
                    }
                }
                comand = Console.ReadLine();
            }
            int index = 0;
            while (people.Count != filtred.Count)
            {
                if (people[index] != filtred[index])
                    people.RemoveAt(index);
                else
                index++;
            }

            Console.WriteLine(string.Join(" ", people));
        }

        private static Predicate<string> GetPredicate(string comand)
        {
            string type = comand.Split(";")[1];
            string input = comand.Split(";")[2];

            Predicate<string> predicate = null;
            if (type == "Starts with")
                predicate = name => name.StartsWith(input);
            else if (type == "Ends with")
                predicate = name => name.EndsWith(input);
            else if (type == "Length")
                predicate = name => name.Length == int.Parse(input);
            else if (type == "Contains")
                predicate = name => name.Contains(input);
            return predicate;
        }
    }
}
