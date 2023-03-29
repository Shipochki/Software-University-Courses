using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
	public class Mission : IMission
	{
		public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
		{
			while (astronauts.Any(a => a.CanBreath) && planet.Items.Any())
			{
				foreach (var a in astronauts.Where(a => a.CanBreath))
				{
					if (!a.CanBreath)
					{
						break;
					}

					a.Bag.Items.Add(planet.Items.First());
					a.Breath();
					planet.Items.Remove(planet.Items.First());
				}
			}
		}
	}
}
