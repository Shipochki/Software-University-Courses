using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using static Heroes.Utilities.Messages.ExceptionMessages;

namespace Heroes.Models.Heroes
{
	public class Hero : IHero
	{
		public Hero(string name, int health, int armour)
		{
			Name = name;
			Health = health;
			Armour = armour;
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(HeroNullName);
				}
				name = value;
			}
		}

		private int health;

		public int Health
		{
			get { return health; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException(HeroHealthNegative);
				}
				health = value;
			}
		}

		private int armour;

		public int Armour
		{
			get { return armour; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException(HeroArmourNegative);
				}
				armour = value;
			}
		}

		private IWeapon weapon;

		public IWeapon Weapon
		{
			get { return weapon; }
			private set
			{
				if (value == null)
				{
					throw new ArgumentException(WeaponNull);
				}
				weapon = value;
			}
		}

		public bool IsAlive
		{
			get
			{
				if (this.health > 0)
				{
					return true;
				}

				return false;
			}
		}

		public void AddWeapon(IWeapon weapon)
		{
			this.Weapon = weapon;
		}

		public void TakeDamage(int points)
		{
			this.armour -= points;
			if (this.armour <= 0)
			{
				int current = points - this.armour;
				this.armour = 0;
				this.health -= current;
				if(this.health <= 0)
				{
					this.health = 0;
				}
			}

		}
	}
}
