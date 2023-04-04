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
			this.health = BaseHealth;
			BaseArmor = armor;
			Armor = BaseArmor;
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

		private double health;
		public double Health
		{
			get
			{
				return this.health;
			}
			set
			{
				if (value > 0)
				{
					if (value > BaseHealth)
					{
						this.health = BaseHealth;
					}
					else
					{
						this.health = value;
					}
				}
			}
		}

		public double BaseArmor { get; set; }

		private double armor;
		public double Armor 
		{
			get
			{
				return this.armor;
			}
			set
			{
				if (value > 0)
				{
					if (value > BaseArmor)
					{
						this.armor = BaseArmor;
					}
					else
					{
						this.armor = value;
					}
				}
			}
		}

		public double AbilityPoints { get; set; }

		public Bag Bag { get; set; }

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
			EnsureAlive();

			if (this.IsAlive)
			{
				double left = this.Armor - hitPoints;
				if (left < 0)
				{
					double leftHealth = this.Health - Math.Abs(left);
					if (leftHealth < 0)
					{
						this.health = 0;
						this.IsAlive = false;
					}
					else
					{
						this.Health = leftHealth;
					}

					this.armor = 0;
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
				Character character = this;
				item.AffectCharacter(character);
			}
		}
	}
}