using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using static Heroes.Utilities.Messages.ExceptionMessages;
using static Heroes.Utilities.Messages.OutputMessages;
using System.Collections.Generic;
using System.Text;
using Heroes.Models.Heroes;
using Heroes.Models.Weapons;
using Heroes.Models.Map;
using System.Linq;
using Heroes.Core.Contracts;

namespace Heroes.Core
{
	public class Controller : IController
	{
		private IRepository<IHero> heroes;
		private IRepository<IWeapon> weapons;

		public Controller()
		{
			this.heroes = new HeroRepository();
			this.weapons = new WeaponRepository();
		}

		public string AddWeaponToHero(string weaponName, string heroName)
		{
			IHero hero = this.heroes.FindByName(heroName);
			if (hero == null)
			{
				throw new InvalidOperationException(string.Format(HeroNotExists, heroName));
			}

			IWeapon weapon = this.weapons.FindByName(weaponName);
			if (weapon == null)
			{
				throw new InvalidOperationException(string.Format(WeaponNotExists, weaponName));
			}

			if(hero.Weapon != null)
			{
				throw new InvalidOperationException(string.Format(HeroArmed, heroName));
			}

			hero.AddWeapon(weapon);
			this.weapons.Remove(weapon);
			return string.Format(WeaponAddedToHero, heroName, weapon.GetType().Name.ToLower());
		}

		public string CreateHero(string type, string name, int health, int armour)
		{
			if (this.heroes.FindByName(name) != null)
			{
				throw new InvalidOperationException(string.Format(HeroExists, name));
			}

			if (type != nameof(Knight) && type != nameof(Barbarian))
			{
				throw new InvalidOperationException(string.Format(HeroTypeInvalid));
			}

			IHero hero;
			if(type == nameof(Barbarian))
			{
				hero = new Barbarian(name, health, armour);
				this.heroes.Add(hero);
				return string.Format(BarbarianAdded, name);
			}
			else
			{
				hero = new Knight(name, health, armour);
				this.heroes.Add(hero);
				return string.Format(KnightAdded, name);
			}
		}

		public string CreateWeapon(string type, string name, int durability)
		{
			if (this.weapons.FindByName(name) != null)
			{
				throw new InvalidOperationException(string.Format(WeaponExists, name));
			}

			if (type != nameof(Mace) && type != nameof(Claymore))
			{
				throw new InvalidOperationException(string.Format(WeaponTypeInvalid));
			}

			IWeapon weapon;
			if (type == nameof(Mace))
			{
				weapon = new Mace(name, durability);
				this.weapons.Add(weapon);
				return string.Format(WeaponAdded, type.ToLower(), name);
			}
			else
			{
				weapon = new Claymore(name, durability);
				this.weapons.Add(weapon);
				return string.Format(WeaponAdded, type.ToLower(), name);
			}
		}

		public string HeroReport()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var hero in this.heroes
				.Models
				.OrderBy(m => m.GetType().Name)
				.ThenByDescending(m => m.Health)
				.ThenBy(m => m.Name))
			{
				sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
				sb.AppendLine($"--Health: { hero.Health }");
				sb.AppendLine($"--Armour: { hero.Armour }");
				if(hero.Weapon != null)
				{
					sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
				}
				else
				{
					sb.AppendLine($"--Weapon: Unarmed");
				}
			}

			return sb.ToString().TrimEnd();
		}

		public string StartBattle()
		{
			IMap map = new Map();
			List<IHero> heroes = this.heroes.Models.ToList();
			return map.Fight(heroes);
		}
	}
}
