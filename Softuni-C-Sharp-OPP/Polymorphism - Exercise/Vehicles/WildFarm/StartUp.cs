namespace WildFarm
{
    using System;
    using WildFarm.AbstractionsClasses;
    using WildFarm.Foods;
    using WildFarm.Animals.Birds;
    using WildFarm.Animals.Mammals;
    using WildFarm.Animals.Mammals.Felines;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string inputData = Console.ReadLine();
                if (inputData == "End")
                    break;

                Animal animal = null;

                var splitedData = inputData.Split();
                string type = splitedData[0];
                string name = splitedData[1];
                double weight = double.Parse(splitedData[2]);

                var splitedFoodData = Console.ReadLine().Split();
                string foodType = splitedFoodData[0];
                int foodQuantity = int.Parse(splitedFoodData[1]);

                if (type == "Hen")
                {
                    double wingSize = double.Parse(splitedData[3]);
                    animal = new Hen(name, weight, wingSize);
                }
                else if (type == "Owl")
                {
                    double wingSize = double.Parse(splitedData[3]);
                    animal = new Owl(name, weight, wingSize);
                }
                else if (type == "Mouse")
                {
                    string livingRegion = splitedData[3];
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (type == "Dog")
                {
                    string livingRegion = splitedData[3];
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (type == "Cat")
                {
                    string livingRegion = splitedData[3];
                    string breed = splitedData[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (type == "Tiger")
                {
                    string livingRegion = splitedData[3];
                    string breed = splitedData[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                }

                animals.Add(animal);

                try
                {
                    animal.Eat(foodType, foodQuantity);
                }
                catch (Exception o)
                {
                    Console.WriteLine(o.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
