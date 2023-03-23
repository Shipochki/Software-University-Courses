using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
	{
		public string Fight(ICollection<IHero> players)
		{
			ICollection<IHero> knights = new List<IHero>();
			ICollection<IHero> barbarians = new List<IHero>();

			foreach (var hero in players)
			{
				if (hero.GetType().Name == nameof(Knight))
				{
					knights.Add(hero);
				}
				else
				{
					barbarians.Add(hero);
				}
			}

			while (knights.Any(k => k.IsAlive)
				|| barbarians.Any(b => b.IsAlive)) ;
			{
				foreach (var knight in knights)
				{
					if (knight.IsAlive)
					{
						foreach (var barbarian in barbarians)
						{
							barbarian.TakeDamage(knight.Weapon.DoDamage());
						}
					}
				}

				foreach (var barbarian in barbarians)
				{
					if (barbarian.IsAlive)
					{
						foreach (var knight in knights)
						{
							knight.TakeDamage(barbarian.Weapon.DoDamage());
						}
					}
				}
			}

			if(knights.Any(k => k.IsAlive))
			{
				int counter = knights.Where(k => !k.IsAlive).Count();
				return $"The knights took {counter} casualties but won the battle.";
			}
			else
			{
				int counter = barbarians.Where(k => !k.IsAlive).Count();
				return $"The barbarians took {counter} casualties but won the battle.";
			}
		}
	}
}
