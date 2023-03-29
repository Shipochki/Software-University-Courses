using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using System;
using static SpaceStation.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
	public class Astronaut : IAstronaut
	{
		public Astronaut(string name, double oxygen)
		{
			Name = name;
			Oxygen = oxygen;
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException(InvalidAstronautName);
				}
				name = value;
			}
		}

		protected double oxygen;

		public double Oxygen
		{
			get { return oxygen; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException(InvalidOxygen);
				}
				oxygen = value;
			}
		}

		private bool canBreath;

		public bool CanBreath => this.canBreath;

		private IBag bag;

		public IBag Bag => this.bag;

		public virtual void Breath()
		{
			if (this.oxygen >= 10)
			{
				this.oxygen -= 10;
			}
		}
	}
}
