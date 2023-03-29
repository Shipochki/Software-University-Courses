using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using System;
using static SpaceStation.Utilities.Messages.ExceptionMessages;
using static SpaceStation.Utilities.Messages.OutputMessages;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Planets;
using System.Linq;
using SpaceStation.Models.Mission;

namespace SpaceStation.Core
{
	public class Controller : IController
	{
		private IRepository<IAstronaut> astronauts;
		private IRepository<IPlanet> planets;
		private int exporetdPlanet;

		public Controller()
		{
			this.astronauts = new AstronautRepository();
			this.planets = new PlanetRepository();
		}

		public string AddAstronaut(string type, string astronautName)
		{
			IAstronaut astronaut = null;
			if (type == nameof(Biologist))
			{
				astronaut = new Biologist(astronautName);
			}
			else if (type == nameof(Geodesist))
			{
				astronaut = new Geodesist(astronautName);
			}
			else if (type == nameof(Meteorologist))
			{
				astronaut = new Meteorologist(astronautName);
			}
			else
			{
				throw new InvalidOperationException(InvalidAstronautType);
			}

			this.astronauts.Add(astronaut);
			return string.Format(AstronautAdded, type, astronautName);
		}

		public string AddPlanet(string planetName, params string[] items)
		{
			IPlanet planet = new Planet(planetName);
			foreach (var item in items)
			{
				planet.Items.Add(item);
			}

			this.planets.Add(planet);
			return string.Format(PlanetAdded, planetName);
		}

		public string ExplorePlanet(string planetName)
		{
			ICollection<IAstronaut> astronauts = this.astronauts.Models.Where(a => a.Oxygen > 60).ToList();
			if (astronauts.Count == 0)
			{
				throw new InvalidOperationException(InvalidAstronautCount);
			}

			IPlanet planet = this.planets.FindByName(planetName);
			Mission mission = new Mission();
			mission.Explore(planet, astronauts);
			int countDeath = astronauts.Where(a => a.Oxygen == 0).Count();
			this.exporetdPlanet++;

			return string.Format(PlanetExplored, planetName, countDeath);
		}

		public string Report()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{this.exporetdPlanet} planets were explored!");
			sb.AppendLine("Astronauts info:");
			foreach (var astronaut in this.astronauts.Models)
			{
				sb.AppendLine($"Name: {astronaut.Name}");
				sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
				if(astronaut.Bag == null || astronaut.Bag.Items.Count == 0)
				{
					sb.AppendLine("Bag items: none");
				}
				else
				{
					sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
				}
			}

			return sb.ToString().TrimEnd();
		}

		public string RetireAstronaut(string astronautName)
		{
			IAstronaut astronaut = this.astronauts.FindByName(astronautName);
			if (astronaut == null)
			{
				throw new InvalidOperationException(string.Format(InvalidRetiredAstronaut, astronautName));
			}

			this.astronauts.Remove(astronaut);
			return string.Format(AstronautRetired, astronautName);
		}
	}
}
