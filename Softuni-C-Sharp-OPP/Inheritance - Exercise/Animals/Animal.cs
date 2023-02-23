using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        protected string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public virtual string ProduceSound()
        {
            return "";
        }

        public string Name { get; set; }
        public int Age
        {
            get { return age; }
            set
            {
                if(value > 0)
                    age = value;
            }
        }

        public virtual string Gender
        {
            get { return gender; }
            set
            {
                if (value == "Male" || value == "Female")
                    gender = value;
            }
        }
    }
}
