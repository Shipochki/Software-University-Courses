using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
	public class Biologist : Astronaut
	{
		private const double initalOxygen = 70;
		public Biologist(string name) : base(name, initalOxygen)
		{
		}

		public override void Breath()
		{
			if (base.oxygen >= 5)
			{
				base.oxygen -= 5;
			}
		}
	}
}
