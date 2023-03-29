using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
	public class PlanetRepository : IRepository<IPlanet>
	{
		public PlanetRepository()
		{
			this.models = new List<IPlanet>();
		}

		private List<IPlanet> models;

		public IReadOnlyCollection<IPlanet> Models => this.models;


		public void Add(IPlanet model)
		{
			this.models.Add(model);
		}

		public IPlanet FindByName(string name)
		{
			return this.models.FirstOrDefault(m => m.Name == name);
		}

		public bool Remove(IPlanet model)
		{
			return this.models.Remove(model);
		}
	}
}
