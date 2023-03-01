using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
            base.Power = 80;
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
