using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> splitedData = Console.ReadLine().Split().ToList();
            string namePizza = splitedData[1];
            Pizza pizza;

            try
            {
                splitedData = Console.ReadLine().Split().ToList();
                string type = splitedData[1];
                string technique = splitedData[2];
                int weight = int.Parse(splitedData[3]);

                Dough dough = new Dough(type, technique, weight);
                pizza = new Pizza(namePizza, dough);
            }
            catch (Exception o)
            {
                Console.WriteLine(o.Message);
                return;
            }


            string inputData = Console.ReadLine();

            while (inputData != "END")
            {
                splitedData = inputData.Split().ToList();
                string comand = splitedData[0];

                if (comand == "Topping")
                {
                    try
                    {
                        string type = splitedData[1];
                        int weight = int.Parse(splitedData[2]);

                        Topping topping = new Topping(type, weight);
                        pizza.AddTopping(topping);
                    }
                    catch (Exception o)
                    {
                        Console.WriteLine(o.Message);
                        return;
                    }
                }

                inputData = Console.ReadLine();
            }

            Console.WriteLine($"{pizza.Name} - {pizza.GetPizzaCalories():f2} Calories.");
        }
    }
}
