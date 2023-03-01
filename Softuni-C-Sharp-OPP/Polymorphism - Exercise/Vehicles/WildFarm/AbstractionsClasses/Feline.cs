using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.AbstractionsClasses
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; set; }
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{base.Name}, {this.Breed}, {this.Weight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
