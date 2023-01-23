using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var peopleInfo = new List<Person>();
            peopleInfo = GetInfoForPeople();

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Func<Person, bool> filter = Filter(condition, age);

            var matchingPeople = peopleInfo.Where(filter).ToList();

            string format = Console.ReadLine();
            Action<Person> printer = Printer(format);

            PrintFilteredPeople(matchingPeople, printer);
        }
        public static List<Person> GetInfoForPeople()
        {
            int numOfPeople = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < numOfPeople; i++)
            {
                var currentPerson = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = currentPerson[0];
                int age = int.Parse(currentPerson[1]);

                var person = new Person(name, age);
                people.Add(person);
            }

            return people;
        }
        public static Func<Person, bool> Filter(string condition, int age)
        {
            if (condition == "younger")
                return x => x.Age < age;
            else if (condition == "older")
                return x => x.Age >= age;
            else
                throw new ArgumentException($"Invalid condition: {condition} or age: {age}");
        }
        public static Action<Person> Printer(string format)
        {
            if (format == "name")
                return person => Console.WriteLine($"{person.Name}");
            else if (format == "age")
                return person => Console.WriteLine($"{person.Age}");
            else if (format == "name age")
                return person => Console.WriteLine($"{person.Name} - {person.Age}");
            else
                throw new ArgumentException($"Invalid format: {format}");
        }
        private static void PrintFilteredPeople(List<Person> peopleInfo, Action<Person> printer)
        {
            foreach (var person in peopleInfo)
            {
                printer(person);
            }
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
