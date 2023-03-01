using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals
{
    using AbstractionsClasses;
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            base.typeFood = new List<string>()
            {
                "Vegetable",
                "Fruit"
            };
        }

        protected override void MakeSound()
        {
            Console.WriteLine("Squeak");
        }

        public override void Eat(string food, int quantity)
        {
            MakeSound();
            if (CorrectFood(food))
            {
                base.Weight += quantity * 0.10;
                base.FoodEaten += quantity;
            }
            else
                throw new ArgumentException($"{GetType().Name} does not eat {food}!");
        }
    }
}
