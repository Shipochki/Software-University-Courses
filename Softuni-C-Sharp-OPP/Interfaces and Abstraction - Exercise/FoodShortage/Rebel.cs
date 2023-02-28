using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        private string name;
        private int age;
        private string group;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            this.age = age;
            this.group = group;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
