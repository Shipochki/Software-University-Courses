using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Birds
{
    using AbstractionsClasses;
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            base.typeFood = new List<string>()
            {
                "Meat"
            };
        }

        protected override void MakeSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void Eat(string food, int quantity)
        {
            MakeSound();
            if (CorrectFood(food))
            {
                base.Weight += quantity * 0.25;
                base.FoodEaten += quantity;
            }
            else
                throw new ArgumentException($"{GetType().Name} does not eat {food}!");
        }
    }
}
