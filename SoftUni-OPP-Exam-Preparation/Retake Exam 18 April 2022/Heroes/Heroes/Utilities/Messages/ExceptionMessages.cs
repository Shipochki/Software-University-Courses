using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Utilities.Messages
{
	public static class ExceptionMessages
	{
		public const string WeaponNullName = "Weapon type cannot be null or empty.";
		public const string WeaponNegativeDurability = "Durability cannot be below 0.";
		public const string HeroNullName = "Hero name cannot be null or empty.";
		public const string HeroHealthNegative = "Hero health cannot be below 0.";
		public const string HeroArmourNegative = "Hero armour cannot be below 0.";
		public const string WeaponNull = "Weapon cannot be null.";

		public const string HeroExists = "The hero {0} already exists.";
		public const string HeroTypeInvalid = "Invalid hero type.";
		public const string WeaponExists = "The weapon {0} already exists.";
		public const string WeaponTypeInvalid = "Invalid weapon type.";
		public const string HeroNotExists = "Hero {0} does not exist.";
		public const string WeaponNotExists = "Weapon {0} does not exist.";
		public const string HeroArmed = "Hero {0} is well-armed.";
	}
}
