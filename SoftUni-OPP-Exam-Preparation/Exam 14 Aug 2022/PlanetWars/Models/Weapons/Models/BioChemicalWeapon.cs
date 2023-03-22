using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons.Models
{
	public class BioChemicalWeapon : Weapon
	{
		private const double price = 3.2;
		public BioChemicalWeapon(int destructionLevel) : 
			base(destructionLevel, price)
		{
		}
	}
}
