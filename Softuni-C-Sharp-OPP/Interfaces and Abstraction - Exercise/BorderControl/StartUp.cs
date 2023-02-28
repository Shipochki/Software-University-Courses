using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ICitizen> citizens = new List<ICitizen>();

            string inputData = Console.ReadLine();

            while (inputData != "End")
            {
                var splitedData = inputData.Split().ToList();

                if(splitedData.Count == 3)
                {
                    string name = splitedData[0];
                    int age = int.Parse(splitedData[1]);
                    string id = splitedData[2];
                    Person person = new Person(name, age, id);
                    citizens.Add(person);
                }
                else
                {
                    string model = splitedData[0];
                    string id = splitedData[1];
                    Robot robot = new Robot(model, id);
                    citizens.Add(robot);
                }

                inputData = Console.ReadLine();
            }

            string lastDigit = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                if(citizen.ID.EndsWith(lastDigit))
                    Console.WriteLine(citizen.ID);
            }
        }
    }
}
