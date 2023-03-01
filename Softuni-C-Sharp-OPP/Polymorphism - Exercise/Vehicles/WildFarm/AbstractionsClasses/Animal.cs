using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WildFarm
{
    using WildFarm.AbstractionsClasses;
    public abstract class Animal
    {
        protected List<string> typeFood;
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        protected virtual void MakeSound()
        {
        }

        public virtual void Eat(string food, int quantity)
        {
        }

        protected virtual bool CorrectFood(string food)
        {
            foreach (var item in typeFood)
            {
                if (item == food)
                    return true;
            }

            return false;
        }
    }
}
