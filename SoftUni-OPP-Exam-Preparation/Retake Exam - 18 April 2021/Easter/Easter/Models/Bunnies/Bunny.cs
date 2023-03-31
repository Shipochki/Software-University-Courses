using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using static Easter.Utilities.Messages.ExceptionMessages;
using System.Text;

namespace Easter.Models.Bunnies
{
	public class Bunny : IBunny
	{
		public Bunny(string name, int energy)
		{
			Name = name;
			this.energy = energy;
			this.dyes = new List<IDye>();
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set 
			{ 
				if(string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidBunnyName);
				}
				name = value; 
			}
		}

		protected int energy;

		public int Energy
		{
			get 
			{ 
				if(this.energy < 0)
				{
					this.energy = 0;
				}
				return energy; 
			}
		}

		private List<IDye> dyes;

		public ICollection<IDye> Dyes => this.dyes;

		public void AddDye(IDye dye)
		{
			this.dyes.Add(dye);
		}

		public virtual void Work()
		{
			if(this.energy - 10 <= 0)
			{
				this.energy = 0;
			}
			else
			{
				this.energy -= 10;
			}
		}
	}
}
