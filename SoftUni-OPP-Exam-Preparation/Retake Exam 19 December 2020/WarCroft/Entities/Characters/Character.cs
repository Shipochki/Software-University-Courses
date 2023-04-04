using System;
using static WarCroft.Constants.ExceptionMessages;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
	public abstract class Character
	{
		public Character(string name, double health, double armor, double abilityPoints, Bag bag)
		{
			Name = name;
			BaseHealth = health;
			Health = health;
			BaseArmor = armor;
			Armor = armor;
			AbilityPoints = abilityPoints;
			Bag = bag;
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(CharacterNameInvalid);
				}
				name = value;
			}
		}

		public double BaseHealth { get; set; }

		public double Health
		{
			get
			{
				return Health;
			}
			set
			{
				if (value > 0)
				{
					if (value + Health > BaseHealth)
					{
						Health = BaseHealth;
					}
					else
					{
						Health = value;
					}
				}
			}
		}

		public double BaseArmor { get; set; }

		public double Armor 
		{
			get
			{
				return Armor;
			}
			set
			{
				if (value > 0)
				{
					if (value + Armor > BaseArmor)
					{
						Armor = BaseArmor;
					}
					else
					{
						Armor = value;
					}
				}
			}
		}

		public double AbilityPoints { get; set; }

		Bag Bag { get; set; }

		public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

		public void TakeDamage(double hitPoints)
		{
			if (this.IsAlive)
			{
				double left = this.Armor - hitPoints;
				if (left < 0)
				{
					double leftHealth = this.Health - left;
					if (leftHealth < 0)
					{
						this.Health = 0;
						this.IsAlive = false;
					}
					else
					{
						this.Health = leftHealth;
					}
				}
				else
				{
					this.Armor = left;
				}
			}
		}

		public void UseItem(Item item)
		{
			if (this.IsAlive)
			{
				item.AffectCharacter(this);
			}
		}
	}
}