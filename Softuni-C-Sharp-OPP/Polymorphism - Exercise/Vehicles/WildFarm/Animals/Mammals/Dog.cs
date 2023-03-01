using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals
{
    using AbstractionsClasses;
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            base.typeFood = new List<string>()
            {
                "Meat"
            };
        }

        protected override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }

        public override void Eat(string food, int quantity)
        {
            MakeSound();
            if (CorrectFood(food))
            {
                base.Weight += quantity * 0.40;
                base.FoodEaten += quantity;
            }
            else
                throw new ArgumentException($"{GetType().Name} does not eat {food}!");
        }
    }
}
