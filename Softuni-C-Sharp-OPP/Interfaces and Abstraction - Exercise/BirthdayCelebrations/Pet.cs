using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : IBirthday
    {
        public Pet(string name, string date)
        {
            Name = name;
            BirthDate = date;
        }

        public string Name { get; set; }
        public string BirthDate { get; set; }
    }
}
