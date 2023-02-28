using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Person : ICitizen, IBirthday, IBuyer
    {
        private string name;
        private int age;

        public Person(string name, int age, string iD, string birthDate)
        {
            Name = name;
            this.age = age;
            ID = iD;
            BirthDate = birthDate;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public string ID { get; set; }
        public string BirthDate { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
