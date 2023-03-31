using Easter.Models.Eggs.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using static Easter.Utilities.Messages.ExceptionMessages;

namespace Easter.Models.Eggs
{
	public class Egg : IEgg
	{
		public Egg(string name, int energyRequired)
		{
			Name = name;
			this.energyRequired = energyRequired;
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set 
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidEggName);
				}
				name = value; 
			}
		}

		private int energyRequired;

		public int EnergyRequired
		{
			get 
			{
				if(this.energyRequired < 0)
				{
					this.energyRequired = 0;
				}
				return energyRequired; 
			}
		}


		public void GetColored()
		{
			if(this.energyRequired - 10 <= 0)
			{
				this.energyRequired = 0;
			}
			else
			{
				this.energyRequired -= 10;
			}
		}

		public bool IsDone()
		{
			if(this.energyRequired == 0)
			{
				return true;
			}

			return false;
		}
	}
}
