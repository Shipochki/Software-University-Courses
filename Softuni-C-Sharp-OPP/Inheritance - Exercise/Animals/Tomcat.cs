﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string Gender
        {
            get { return base.gender; }
            set { base.gender = "Male"; }
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
