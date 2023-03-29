using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using static SpaceStation.Utilities.Messages.ExceptionMessages;

namespace SpaceStation.Models.Planets
{
	public class Planet : IPlanet
	{
		public Planet(string name)
		{
			Name = name;
			this.items = new List<string>();
		}

		private ICollection<string> items;

		public ICollection<string> Items => this.items;

		private string name;

		public string Name
		{
			get { return name; }
			private set 
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException(InvalidPlanetName);
				}
				name = value; 
			}
		}

	}
}
