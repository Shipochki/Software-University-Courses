using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
	public class SleepyBunny : Bunny
	{
		private const int initalEnergy = 50;
		public SleepyBunny(string name) : base(name, initalEnergy)
		{
		}

		public override void Work()
		{
			base.energy -= 5;
			base.Work();
		}
	}
}
