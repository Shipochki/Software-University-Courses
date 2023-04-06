using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using static EasterRaces.Utilities.Messages.ExceptionMessages;
using System.Text;
using System.Linq;

namespace EasterRaces.Models.Races.Entities
{
	public class Race : IRace
	{
		public Race(string name, int laps)
		{
			Name = name;
			Laps = laps;
			this.drivers = new List<IDriver>();
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

		private int laps;

		public int Laps
		{
			get { return laps; }
			private set 
			{ 
				if(value < 1)
				{
					throw new ArgumentException(string.Format(InvalidNumberOfLaps, 1));
				}
				laps = value; 
			}
		}

		private List<IDriver> drivers;

		public IReadOnlyCollection<IDriver> Drivers => drivers;


		public void AddDriver(IDriver driver)
		{
			if(driver == null)
			{
				throw new ArgumentNullException(DriverInvalid);
			}

			if (!driver.CanParticipate)
			{
				throw new ArgumentException(string.Format(DriverNotParticipate, driver.Name));
			}

			if(this.drivers.Any(d => d.Name == driver.Name))
			{
				throw new ArgumentNullException(string.Format(DriverAlreadyAdded, driver.Name, this.name));
			}

			this.drivers.Add(driver);
		}
	}
}
