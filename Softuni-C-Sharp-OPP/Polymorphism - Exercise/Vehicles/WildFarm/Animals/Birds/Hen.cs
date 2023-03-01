using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Birds
{
    using AbstractionsClasses;
    internal class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override void MakeSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(string food, int quantity)
        {
            base.Weight += quantity * 0.35;
            base.FoodEaten += quantity;
            MakeSound();
        }
    }
}
