using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthday> listOfPeopleAndPets = new List<IBirthday>();

            string inputData = Console.ReadLine();

            while (inputData != "End")
            {
                var splitedData = inputData.Split().ToArray();
                string comand = splitedData[0];
                string name = splitedData[1];

                if(comand == "Citizen")
                {
                    int age = int.Parse(splitedData[2]);
                    string id = splitedData[3];
                    string birthDate = splitedData[4];
                    Person person = new Person(name, age, id, birthDate);
                    listOfPeopleAndPets.Add(person);
                }
                else if(comand == "Pet")
                {
                    string birthDate = splitedData[2];
                    Pet pet = new Pet(name, birthDate);
                    listOfPeopleAndPets.Add(pet);
                }
                else if(comand == "Robot")
                {
                    string id = splitedData[2];
                    Robot robot = new Robot(name, id);
                }

                inputData = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var item in listOfPeopleAndPets)
            {
                if(item.BirthDate.EndsWith(year))
                    Console.WriteLine(item.BirthDate);
            }
        }
    }
}
