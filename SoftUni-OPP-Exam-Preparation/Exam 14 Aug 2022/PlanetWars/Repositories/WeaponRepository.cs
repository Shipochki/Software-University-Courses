﻿using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Models.Weapons.Contracts;
using System.Linq;

namespace PlanetWars.Repositories
{
	public class WeaponRepository : IRepository<IWeapon>
	{
		private List<IWeapon> models = new List<IWeapon>();

		public IReadOnlyCollection<IWeapon> Models => models;

		public void AddItem(IWeapon model)
		{
			this.models.Add(model);
		}

		public IWeapon FindByName(string name)
		{
			return this.models.FirstOrDefault(m => m.GetType().Name == name);
		}

		public bool RemoveItem(string name)
		{
			IWeapon weapon = this.FindByName(name);
			if(weapon == null)
			{
				return false;
			}

			this.models.Remove(weapon);

			return true;
		}
	}
}
