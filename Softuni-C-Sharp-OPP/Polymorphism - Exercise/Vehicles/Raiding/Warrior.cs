using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            base.Power = 100;
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
