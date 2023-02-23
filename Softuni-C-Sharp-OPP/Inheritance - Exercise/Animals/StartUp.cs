using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string inputData = Console.ReadLine();

            while (inputData != "Beast!")
            {
                string typeAnimal = inputData;
                string[] splitedData = Console.ReadLine().Split().ToArray();
                string name = splitedData[0];
                int age = int.Parse(splitedData[1]);
                string gender = splitedData[2];

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    inputData = Console.ReadLine();
                    continue;
                }
                else if (gender != "Male" && gender != "Female")
                {
                    Console.WriteLine("Invalid input!");
                    inputData = Console.ReadLine();
                    continue;
                }


                if (typeAnimal == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }
                else if (typeAnimal == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }
                else if (typeAnimal == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    animals.Add(frog);
                }
                else if (typeAnimal == "Kittens")
                {
                    Kitten kittens = new Kitten(name, age, gender);
                    animals.Add(kittens);
                }
                else if (typeAnimal == "Tomcat")
                {
                    Tomcat tomcats = new Tomcat(name, age, gender);
                    animals.Add(tomcats);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                inputData = Console.ReadLine();
            }

            PrintData(animals);
        }

        private static void PrintData(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                string[] type = animal.GetType().ToString().Split(".").ToArray();
                Console.WriteLine(type[type.Length - 1]);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
