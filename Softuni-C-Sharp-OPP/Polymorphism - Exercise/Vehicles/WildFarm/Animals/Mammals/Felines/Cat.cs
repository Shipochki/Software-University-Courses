using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals.Felines
{
    using AbstractionsClasses;
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            base.typeFood = new List<string>()
            {
                "Vegetable",
                "Meat"
            };
        }

        protected override void MakeSound()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(string food, int quantity)
        {
            MakeSound();
            if (CorrectFood(food))
            {
                base.Weight += quantity * 0.30;
                base.FoodEaten += quantity;
            }
            else
                throw new ArgumentException($"{GetType().Name} does not eat {food}!");
        }
    }
}
