using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < lines; i++)
            {
                string[] inputData = Console.ReadLine().Split();

                string name = inputData[0];
                int age = int.Parse(inputData[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            var oldestPersons = family.GetOldestMembers().OrderBy(m => m.Name);

            foreach (var person in oldestPersons)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
