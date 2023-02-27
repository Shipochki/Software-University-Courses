using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double Base_Cal_Per_Gram = 2;
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

        private double Type;
        private double Weight;

        public Topping(string type, int grams)
        {
            string currentType = type;
            type = type.ToLower();
            if (type == "meat")
                this.Type = Meat;
            else if (type == "veggies")
                this.Type = Veggies;
            else if (type == "cheese")
                this.Type = Cheese;
            else if (type == "sauce")
                this.Type = Sauce;
            else
                throw new ArgumentException($"Cannot place {currentType} on top of your pizza.");

            if (grams > 0 && grams <= 50)
                this.Weight = grams;
            else
                throw new ArgumentException($"{currentType} weight should be in the range [1..50].");

        }

        public double GetToppingCalories()
        {
            return Weight * Base_Cal_Per_Gram * Type;
        }
    }
}
