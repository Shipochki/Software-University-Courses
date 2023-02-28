using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Person : ICitizen
    {
        private string name;
        private int age;
        public Person(string name, int age, string iD)
        {
            this.name = name;
            this.age = age;
            ID = iD;
        }

        public string ID { get; set; }
    }
}
