using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using static PlanetWars.Utilities.Messages.ExceptionMessages;
using System.Text;
using System.Linq;
using PlanetWars.Repositories;
using PlanetWars.Models.MilitaryUnits.Models;
using PlanetWars.Models.Weapons.Models;

namespace PlanetWars.Models.Planets.Models
{
	public class Planet : IPlanet
	{
		private IRepository<IMilitaryUnit> units;
		private IRepository<IWeapon> weapons;

		public Planet(string name, double budget)
		{
			Name = name;
			Budget = budget;
			this.units = new UnitRepository();
			this.weapons = new WeaponRepository();
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidPlanetName);
				}
				name = value;
			}
		}

		private double budget;

		public double Budget
		{
			get { return budget; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException(InvalidBudgetAmount);
				}
				budget = value;
			}
		}

		public double MilitaryPower => TotalAmount();

		private double TotalAmount()
		{
			double amount =
				this.units.Models.Sum(a => a.EnduranceLevel) +
				this.weapons.Models.Sum(w => w.DestructionLevel);
			if (this.units.FindByName(nameof(AnonymousImpactUnit)) != null && 
				this.units.FindByName(nameof(AnonymousImpactUnit)).GetType().Name
				== nameof(AnonymousImpactUnit))
			{
				amount += amount * 0.3;
			}

			if (this.weapons.FindByName(nameof(NuclearWeapon)) != null &&
				this.weapons.FindByName(nameof(NuclearWeapon)).GetType().Name 
				== nameof(NuclearWeapon))
			{
				amount += amount * 0.45;
			}

			return Math.Round(amount, 3);
		}


		public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

		public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;


		public void AddUnit(IMilitaryUnit unit)
		{
			this.units.AddItem(unit);
		}

		public void AddWeapon(IWeapon weapon)
		{
			this.weapons.AddItem(weapon);
		}

		public string PlanetInfo()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Planet: {this.name}");
			sb.AppendLine($"--Budget: {this.budget} billion QUID");

			if (this.Army.Count == 0)
			{
				sb.AppendLine("--Forces: No units");
			}
			else
			{
				sb.AppendLine($"--Forces: {string.Join(", ", this.Army.Select(a => a.GetType().Name))}");
			}

			if (this.Weapons.Count == 0)
			{
				sb.AppendLine($"--Combat equipment: No weapons");
			}
			else
			{
				sb.AppendLine($"--Combat equipment: {string.Join(", ", this.Weapons.Select(w => w.GetType().Name))}");
			}

			sb.AppendLine($"--Military Power: {this.MilitaryPower}");

			return sb.ToString().TrimEnd();
		}

		public void Profit(double amount)
		{
			this.budget += amount;
		}

		public void Spend(double amount)
		{
			if (this.budget < amount)
			{
				throw new InvalidOperationException(UnsufficientBudget);
			}

			this.budget -= amount;
		}

		public void TrainArmy()
		{
			foreach (var unit in this.units.Models)
			{
				unit.IncreaseEndurance();
			}
		}
	}
}
