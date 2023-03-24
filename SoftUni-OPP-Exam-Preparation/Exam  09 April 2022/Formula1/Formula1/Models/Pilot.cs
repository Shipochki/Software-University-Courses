using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Formula1.Utilities.ExceptionMessages;

namespace Formula1.Models
{
	public class Pilot : IPilot
	{
		public Pilot(string fullName)
		{
			FullName = fullName;
		}

		private string fullName;

		public string FullName
		{
			get { return fullName; }
			private set 
			{ 
				if(string.IsNullOrEmpty(value) || value.Length < 5)
				{
					throw new ArgumentException(string.Format(InvalidPilot, fullName));
				}
				fullName = value; 
			}
		}

		private IFormulaOneCar car;

		public IFormulaOneCar Car
		{
			get { return car; }
			private set 
			{
				if(value == null)
				{
					throw new NullReferenceException(InvalidCarForPilot);
				}
				car = value; 
			}
		}

		private int numberOfWins = 0;

		public int NumberOfWins
		{
			get { return numberOfWins; }
		}

		private bool canRace = false;

		public bool CanRace
		{
			get { return canRace; }
		}


		public void AddCar(IFormulaOneCar car)
		{
			Car = car;
			this.canRace = true;
		}

		public void WinRace()
		{
			this.numberOfWins++;
		}

		public override string ToString()
		{
			return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
		}
	}
}
