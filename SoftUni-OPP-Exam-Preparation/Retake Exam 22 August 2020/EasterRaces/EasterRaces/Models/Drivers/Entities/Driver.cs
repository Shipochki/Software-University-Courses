using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using static EasterRaces.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
	public class Driver : IDriver
	{
		public Driver(string name)
		{
			Name = name;
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set
			{
				if (string.IsNullOrEmpty(value) || value.Length < 5)
				{
					throw new ArgumentException(string.Format(InvalidName, value, 5));
				}
				name = value;
			}
		}

		private ICar car;

		public ICar Car => car;

		private int numberOfWins;

		public int NumberOfWins => numberOfWins;

		private bool canParticipate = false;
		public bool CanParticipate => canParticipate;

		public void AddCar(ICar car)
		{
			if (car == null)
			{
				throw new ArgumentNullException(CarInvalid);
			}

			this.car = car;
			this.canParticipate = true;
		}

		public void WinRace()
		{
			this.numberOfWins++;
		}
	}
}
