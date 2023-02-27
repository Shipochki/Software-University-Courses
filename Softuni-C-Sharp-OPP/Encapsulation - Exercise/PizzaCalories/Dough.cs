using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;

        private double Type;
        private double Technique;
        private int Weight;

        public Dough(string type, string technique, int weight)
        {
            type = type.ToLower();
            if (type == "white")
                this.Type = White;
            else if (type == "wholegrain")
                this.Type = Wholegrain;
            else
                throw new ArgumentException("Invalid type of dough.");

            technique = technique.ToLower();
            if (technique == "crispy")
                this.Technique = Crispy;
            else if (technique == "chewy")
                this.Technique = Chewy;
            else if (technique == "homemade")
                this.Technique = Homemade;
            else
                throw new ArgumentException("Invalid type of dough.");

            if (weight > 0 && weight <= 200)
                this.Weight = weight;
            else
                throw new ArgumentException("Dough weight should be in the range [1..200].");
        }

        public double GetDoughCalories()
        {
            return (2 * this.Weight) * this.Type * this.Technique;
        }
    }
}
