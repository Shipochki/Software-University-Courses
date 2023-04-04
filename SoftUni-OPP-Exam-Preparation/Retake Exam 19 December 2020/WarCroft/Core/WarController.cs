using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
using static WarCroft.Constants.ExceptionMessages;

namespace WarCroft.Core
{
	public class WarController
	{
		private ICollection<Character> party;
		private ICollection<Item> pool;
		public WarController()
		{
			party = new List<Character>();
			pool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			if (characterType != nameof(Warrior) && characterType != nameof(Priest))
			{
				throw new ArgumentException(InvalidCharacterType, characterType);
			}

			string name = args[1];
			Character character;
			if (characterType == nameof(Warrior))
			{
				character = new Warrior(name);
			}
			else
			{
				character = new Priest(name);
			}

			this.party.Add(character);
			return string.Format(Constants.SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			if (itemName != nameof(FirePotion) && itemName != nameof(HealthPotion))
			{
				throw new ArgumentException(string.Format(InvalidItem, itemName));
			}

			Item item;
			if (itemName == nameof(FirePotion))
			{
				item = new FirePotion();
			}
			else
			{
				item = new HealthPotion();
			}
			this.pool.Add(item);
			return string.Format(Constants.SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			Character character = this.party.FirstOrDefault(c => c.Name == characterName);
			if (character == null)
			{
				throw new ArgumentException(string.Format(CharacterNotInParty, characterName));
			}

			if (this.pool.Count == 0)
			{
				throw new InvalidOperationException(ItemPoolEmpty);
			}

			Item item = this.pool.Last();
			character.Bag.AddItem(item);
			this.pool.Remove(item);

			return string.Format(Constants.SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			Character character = this.party.FirstOrDefault(c => c.Name == characterName);
			if (character == null)
			{
				throw new ArgumentException(string.Format(CharacterNotInParty, characterName));
			}

			string itemName = args[1];
			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(Constants.SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var character in this.party
				.OrderByDescending(c => c.IsAlive)
				.ThenByDescending(c => c.Health))
			{
				if (character.IsAlive)
				{
					sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: Alive");
				}
				else
				{
					sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: Dead");
				}
			}

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Warrior attacker = (Warrior)this.party.FirstOrDefault(c => c.Name == attackerName);
			Character receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

			if (attacker == null)
			{
				throw new ArgumentException(string.Format(CharacterNotInParty, attackerName));
			}
			else if (receiver == null)
			{
				throw new ArgumentException(string.Format(CharacterNotInParty, receiverName));
			}

			if (!attacker.IsAlive) 
			{
				throw new ArgumentException(string.Format(AttackFail, attackerName));
			}

			attacker.Attack(receiver);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

			if(!receiver.IsAlive) 
			{
				sb.AppendLine($"{receiver.Name} is dead!");
			}

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string receiverName = args[1];

			Character healer = this.party.FirstOrDefault(c => c.Name == healerName);
			Character receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

			if (healer == null)
			{
				throw new ArgumentException(string.Format(CharacterNotInParty, healerName));
			}
			else if (receiver == null)
			{
				throw new ArgumentException(string.Format(CharacterNotInParty, receiverName));
			}

			if (!healer.IsAlive)
			{
				throw new ArgumentException(string.Format(HealerCannotHeal, healerName));
			}

			receiver.Health += healer.AbilityPoints;

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
