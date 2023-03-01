using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public BaseHero(string name)
        {
            Name = name;
        }

        public virtual string CastAbility()
        {
            return Name;
        }
    }
}
