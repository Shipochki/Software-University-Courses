using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Person : ICitizen, IBirthday
    {
        private string name;
        private int age;

        public Person(string name, int age, string iD, string birthDate)
        {
            this.name = name;
            this.age = age;
            ID = iD;
            BirthDate = birthDate;
        }

        public string ID { get; set; }
        public string BirthDate { get; set; }
        
    }
}
