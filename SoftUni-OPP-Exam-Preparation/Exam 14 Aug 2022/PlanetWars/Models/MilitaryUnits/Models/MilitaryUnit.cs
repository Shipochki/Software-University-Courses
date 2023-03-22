using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using static PlanetWars.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits.Models
{
	public class MilitaryUnit : IMilitaryUnit
	{
		public MilitaryUnit(double cost)
		{
			Cost = cost;
		}
		
		private double cost;

		public double Cost
		{
			get { return cost; }
			private set { cost = value; }
		}

		private int enduranceLevel = 1;

		public int EnduranceLevel
		{
			get { return enduranceLevel; }
		}


		public void IncreaseEndurance()
		{
			if(this.enduranceLevel + 1 > 20)
			{
				throw new ArgumentException(EnduranceLevelExceeded);
			}

			this.enduranceLevel++;
		}
	}
}
