using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.AbstractionsClasses
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; set; }

        public Bird(string name,double weight, double wingSize)
        {
            base.Name = name;
            base.Weight = weight;
            this.WingSize = wingSize;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{base.Name}, {this.WingSize}, {base.Weight}, {base.FoodEaten}]";
        }
    }
}
