using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using static Heroes.Utilities.Messages.ExceptionMessages;

namespace Heroes.Models.Weapons
{
	public class Weapon : IWeapon
	{
		public Weapon(string name, int durability)
		{
			Name = name;
			Durability = durability;
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set 
			{ 
				if(string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(WeaponNullName);
				}
				name = value; 
			}
		}

		private int durability;

		public int Durability
		{
			get { return durability; }
			private set 
			{ 
				if(value < 0)
				{
					throw new ArgumentException(WeaponNegativeDurability);
				}
				durability = value; 
			}
		}

		public int DoDamage()
		{
			if(this.durability < 1)
			{
				return 0;
			}

			this.durability--;
			
			if(this.GetType().Name == nameof(Mace))
			{
				return 25;
			}
			else
			{
				return 20;
			}
		}
	}
}
