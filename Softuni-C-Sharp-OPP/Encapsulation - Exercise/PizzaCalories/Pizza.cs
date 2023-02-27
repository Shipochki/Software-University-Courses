using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private double Calories;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
            Calories = this.dough.GetDoughCalories();
        }

        public string Name
        {
            get { return this.name; }
            set 
            {
                if (value.Length > 0 && value.Length <= 15)
                    this.name = value;
                else
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
        }

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
            Calories += topping.GetToppingCalories();

            if (this.toppings.Count > 10)
                throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

        public double GetPizzaCalories()
        {
            return Calories;
        }
    }
}
