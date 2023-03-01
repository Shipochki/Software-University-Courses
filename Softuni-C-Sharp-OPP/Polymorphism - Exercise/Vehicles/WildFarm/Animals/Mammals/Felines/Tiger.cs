using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals.Felines
{
    using AbstractionsClasses;
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            base.typeFood = new List<string>()
            {
                "Meat"
            };
        }

        protected override void MakeSound()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Eat(string food, int quantity)
        {
            MakeSound();
            if (CorrectFood(food))
            {
                base.Weight += quantity;
                base.FoodEaten += quantity;
            }
            else
                throw new ArgumentException($"{GetType().Name} does not eat {food}!");
        }
    }
}
