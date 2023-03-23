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
	}
}
