using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
	public class Tests
	{
		[TestFixture]
		public class PlanetWarsTests
		{
			[Test]
			public void Test1()
			{
				Weapon weapon = new Weapon("Sword", 25, 5);

				Assert.That(weapon.Name.Equals("Sword"));

				Assert.That(weapon.DestructionLevel.Equals(5));

				Assert.That(weapon.Price.Equals(25));

				weapon.IncreaseDestructionLevel();

				Assert.That(weapon.DestructionLevel.Equals(6));

				Weapon nuclear = new Weapon("Sword", 25, 10);

				Assert.That(nuclear.IsNuclear.Equals(true));

				Assert.Throws<ArgumentException>(() =>
				{
					Weapon weapon2 = new Weapon("Sword", -1, 5);
				});
			}

			[Test]
			public void Test2()
			{
				Weapon weapon = new Weapon("Sword", 5, 5);
				Weapon nuclear = new Weapon("Sword", 5, 10);

				Planet planet = new Planet("Planet", 25);
				Planet planet1 = new Planet("Planet1", 5);
				planet1.AddWeapon(nuclear);

				Assert.Throws<ArgumentException>(() =>
				{
					Planet planet = new Planet(null, 25);
				});

				Assert.Throws<ArgumentException>(() =>
				{
					Planet planet1 = new Planet("Penko", -1);
				});

				Assert.Throws<InvalidOperationException>(() =>
				{
					planet.SpendFunds(26);
				});

				planet.AddWeapon(weapon);

				Assert.Throws<InvalidOperationException>(() => {
					planet.AddWeapon(weapon);
				});

				Assert.Throws<InvalidOperationException>(() =>
				{
					planet.UpgradeWeapon("penko");
				});

				Assert.Throws<InvalidOperationException>(() =>
				{
					planet.DestructOpponent(planet1);
				});
			}

			[Test]
			public void Test3()
			{
				Weapon weapon = new Weapon("Sword", 5, 5);
				Weapon nuclear = new Weapon("Nuc", 5, 10);

				Planet planet = new Planet("Planet", 25);
				Planet planet1 = new Planet("Planet1", 5);

				planet.AddWeapon(weapon);
				planet.AddWeapon(nuclear);

				Assert.That(planet.Name.Equals("Planet"));

				Weapon testWeapon = planet.Weapons.FirstOrDefault();
				Assert.That(testWeapon.Equals(weapon));

				Assert.That(planet.Weapons.Count.Equals(2));

				Assert.That(planet.MilitaryPowerRatio.Equals(15));

				planet.Profit(5);

				Assert.That(planet.Budget.Equals(30));

				planet.SpendFunds(5);

				Assert.That(planet.Budget.Equals(25));

				planet.RemoveWeapon("Nuc");

				Assert.That(planet.Weapons.Count.Equals(1));

				planet.UpgradeWeapon("Sword");
				
				Assert.That(planet.Weapons.First().DestructionLevel.Equals(6));

				string result = planet.DestructOpponent(planet1);
				string expectedResult = "Planet1 is destructed!";

				Assert.That(result.Equals(expectedResult));
			}
		}
	}
}
