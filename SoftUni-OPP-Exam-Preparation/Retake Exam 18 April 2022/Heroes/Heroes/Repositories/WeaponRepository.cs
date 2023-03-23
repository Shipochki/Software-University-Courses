using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
	public class WeaponRepository : IRepository<IWeapon>
	{
		private List<IWeapon> models = new List<IWeapon>();

		public IReadOnlyCollection<IWeapon> Models => models;


		public void Add(IWeapon model)
		{
			this.models.Add(model);
		}

		public IWeapon FindByName(string name)
		{
			return this.models.FirstOrDefault(m => m.Name == name);
		}

		public bool Remove(IWeapon model)
		{
			if (models.Contains(model))
			{
				this.models.Remove(model);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
