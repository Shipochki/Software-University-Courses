using PlanetWars.Core.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using System;
using static PlanetWars.Utilities.Messages.OutputMessages;
using static PlanetWars.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Models.Planets.Models;
using PlanetWars.Models.MilitaryUnits.Models;
using System.Linq;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons.Models;
using PlanetWars.Models.Weapons.Contracts;

namespace PlanetWars.Core
{
	public class Controller : IController
	{
		private IRepository<IPlanet> planets = new PlanetRepository();

		public string AddUnit(string unitTypeName, string planetName)
		{
			IPlanet planet = this.planets.FindByName(planetName);

			if (planet == null)
			{
				throw new InvalidOperationException(string.Format(UnexistingPlanet, planetName));
			}

			if (unitTypeName != nameof(AnonymousImpactUnit) &&
				unitTypeName != nameof(SpaceForces) &&
				unitTypeName != nameof(StormTroopers))
			{
				throw new InvalidOperationException(string.Format(ItemNotAvailable, unitTypeName));
			}

			if (planet.Army.Any(a => a.GetType().Name == unitTypeName))
			{
				throw new InvalidOperationException(string.Format(UnitAlreadyAdded, unitTypeName, planetName));
			}

			IMilitaryUnit unit = null;

			if (unitTypeName == nameof(AnonymousImpactUnit))
			{
				unit = new AnonymousImpactUnit();
			}
			else if (unitTypeName == nameof(SpaceForces))
			{
				unit = new SpaceForces();
			}
			else if (unitTypeName == nameof(StormTroopers))
			{
				unit = new StormTroopers();
			}

			planet.Spend(unit.Cost);
			planet.AddUnit(unit);

			return string.Format(UnitAdded, unitTypeName, planetName);
		}

		public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
		{
			IPlanet planet = this.planets.FindByName(planetName);

			if (planet == null)
			{
				throw new InvalidOperationException(string.Format(UnexistingPlanet, planetName));
			}

			if (planet.Weapons.Any(a => a.GetType().Name == weaponTypeName))
			{
				throw new InvalidOperationException(string.Format(WeaponAlreadyAdded, weaponTypeName, planetName));
			}

			if (weaponTypeName != nameof(BioChemicalWeapon) &&
				weaponTypeName != nameof(NuclearWeapon) &&
				weaponTypeName != nameof(SpaceMissiles))
			{
				throw new InvalidOperationException(string.Format(ItemNotAvailable, weaponTypeName));
			}

			IWeapon weapon = null;

			if (weaponTypeName == nameof(BioChemicalWeapon))
			{
				weapon = new BioChemicalWeapon(destructionLevel);
			}
			else if (weaponTypeName == nameof(NuclearWeapon))
			{
				weapon = new NuclearWeapon(destructionLevel);
			}
			else if (weaponTypeName == nameof(SpaceMissiles))
			{
				weapon = new SpaceMissiles(destructionLevel);
			}

			planet.Spend(weapon.Price);
			planet.AddWeapon(weapon);

			return string.Format(WeaponAdded, planetName, weaponTypeName);
		}

		public string CreatePlanet(string name, double budget)
		{
			if (this.planets.FindByName(name) != null)
			{
				return string.Format(ExistingPlanet, name);
			}

			IPlanet planet = new Planet(name, budget);

			this.planets.AddItem(planet);

			return string.Format(NewPlanet, name);
		}

		public string ForcesReport()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
			foreach (var planet in this.planets
				.Models
				.OrderByDescending(p => p.MilitaryPower)
				.ThenBy(p => p.Name))
			{
				sb.AppendLine(planet.PlanetInfo());
			}

			return sb.ToString().TrimEnd();
		}

		public string SpaceCombat(string planetOne, string planetTwo)
		{
			IPlanet planet1 = this.planets.FindByName(planetOne);
			IPlanet planet2 = this.planets.FindByName(planetTwo);
			IPlanet winner = null;
			IPlanet losser = null;
			if (planet1.MilitaryPower == planet2.MilitaryPower)
			{
				bool planet1Contain = planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon));
				bool planet2Contain = planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon));
				if (planet1Contain && planet2Contain)
				{
					planet1.Spend(planet1.Budget / 2);
					planet2.Spend(planet2.Budget / 2);
					return string.Format(NoWinner);
				}
				else if(!planet1Contain && !planet2Contain)
				{
					planet1.Spend(planet1.Budget / 2);
					planet2.Spend(planet2.Budget / 2);
					return string.Format(NoWinner);
				}
				else if (planet1Contain)
				{
					winner = planet1;
					losser = planet2;
				}
				else
				{
					winner = planet2;
					losser = planet1;
				}
			}
			else if (planet1.MilitaryPower > planet2.MilitaryPower)
			{
				winner = planet1;
				losser = planet2;
			}
			else
			{
				winner = planet2;
				losser = planet1;
			}

			winner.Spend(winner.Budget / 2);
			winner.Profit(losser.Budget / 2);
			winner.Profit(losser.Army.Sum(a => a.Cost));
			winner.Profit(losser.Weapons.Sum(a => a.Price));
			this.planets.RemoveItem(losser.Name);

			return string.Format(WinnigTheWar, winner.Name, losser.Name);
		}

		public string SpecializeForces(string planetName)
		{
			IPlanet planet = this.planets.FindByName(planetName);

			if (planet == null)
			{
				throw new InvalidOperationException(string.Format(UnexistingPlanet, planetName));
			}

			if (planet.Army.Count == 0)
			{
				throw new InvalidOperationException(NoUnitsFound);
			}

			planet.TrainArmy();
			planet.Spend(1.25);

			return string.Format(ForcesUpgraded, planetName);
		}
	}
}
