using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format($"Name: {Name}, Age: {Age}"));
            return stringBuilder.ToString();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public virtual int Age
        {
            get { return this.age; }
            set
            {
                if (value > 0)
                    this.age = value;
            }
        }

    }
}
