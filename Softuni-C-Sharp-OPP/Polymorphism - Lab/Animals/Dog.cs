﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favoriteFood) : base(name, favoriteFood)
        {
        }

        public override string ExplainSelf()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ExplainSelf());
            sb.AppendLine("DJAAF");
            return sb.ToString().Trim();
        }
    }
}
