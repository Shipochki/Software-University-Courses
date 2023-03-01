using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.AbstractionsClasses
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; set; }

        public Mammal(string name, double weight, string livingRegion)
        {
            base.Name = name;
            base.Weight = weight;
            this.LivingRegion = livingRegion;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{base.Name}, {this.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
