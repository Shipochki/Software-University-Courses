using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyerList = new List<IBuyer>();
            int numOfBuyers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfBuyers; i++)
            {
                var splitedData = Console.ReadLine().Split().ToArray();
                string name = splitedData[0];
                int age = int.Parse(splitedData[1]);
                if(splitedData.Length == 4)
                {
                    string id = splitedData[2];
                    string birthDate = splitedData[3];
                    Person person = new Person(name, age, id, birthDate);
                    buyerList.Add(person);
                }
                else
                {
                    string group = splitedData[2];
                    Rebel rebel = new Rebel(name, age, group);
                    buyerList.Add(rebel);
                }
            }

            string inputData = Console.ReadLine();

            while (inputData != "End")
            {
                if (buyerList.Any(x => x.Name == inputData))
                    foreach (var buyer in buyerList)
                    {
                        if (buyer.Name == inputData)
                        {
                            buyer.BuyFood();
                            break;
                        }
                    }

                inputData = Console.ReadLine();
            }

            Console.WriteLine(buyerList.Select(x => x.Food).Sum());
        }
    }
}
