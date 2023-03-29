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
			while (astronauts.Any(a => a.Oxygen > 0) && planet.Items.Any())
			{
				foreach (var a in astronauts)
				{
					if (!planet.Items.Any())
					{
						break;
					}

					foreach (var item in planet.Items)
					{
						if (a.Oxygen == 0)
						{
							break; ;
						}

						a.Bag.Items.Add(item);
						a.Breath();
					}

					foreach (var item in a.Bag.Items)
					{
						planet.Items.Remove(item);
					}
				}
			}
		}
	}
}
