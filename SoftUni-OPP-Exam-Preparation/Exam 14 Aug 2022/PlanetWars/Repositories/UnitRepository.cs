using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
	public class UnitRepository : IRepository<IMilitaryUnit>
	{
		private List<IMilitaryUnit> models = new List<IMilitaryUnit>();
 
		public IReadOnlyCollection<IMilitaryUnit> Models => this.models;

		public void AddItem(IMilitaryUnit model)
		{
			this.models.Add(model);
		}

		public IMilitaryUnit FindByName(string name)
		{
			return this.models.FirstOrDefault(m => m.GetType().Name == name);
		}

		public bool RemoveItem(string name)
		{
			IMilitaryUnit unit = this.FindByName(name);
			if (unit == null)
			{
				return false;
			}

			this.models.Remove(unit);

			return true;
		}
	}
}
