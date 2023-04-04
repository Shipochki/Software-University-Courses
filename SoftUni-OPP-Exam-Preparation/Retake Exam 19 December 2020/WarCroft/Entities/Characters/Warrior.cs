﻿using System;
using System.Collections.Generic;
using System.Text;
using static WarCroft.Constants.ExceptionMessages;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
	public class Warrior : Character, IAttacker
	{
		public Warrior(string name) 
			: base(name, 100, 50, 40, new Satchel())
		{
		}

		public void Attack(Character character)
		{
			Character attacker = this;

			if(character == attacker)
			{
				throw new InvalidOperationException(CharacterAttacksSelf);
			}

			character.TakeDamage(this.AbilityPoints);
		}
	}
}