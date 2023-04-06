using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("Vw", 130, 1900);
            UnitDriver driver = new UnitDriver("Name", car);

            string result = race.AddDriver(driver);
            string expected = $"Driver Name added in race.";

            Assert.That(result.Equals(expected));

            Assert.That(race.Counter.Equals(1));
		}

        [Test]
        public void Test2()
        {
			RaceEntry race = new RaceEntry();
			UnitCar car = new UnitCar("Vw", 130, 1900);
			UnitDriver driver = new UnitDriver("Name", car);

			race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(null);
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver);
            });
		}

        [Test]
        public void Test3()
        {
			RaceEntry race = new RaceEntry();
			UnitCar car = new UnitCar("Vw", 130, 1900);
            UnitCar car2 = new UnitCar("Mercedes", 270, 3500);
			UnitDriver driver = new UnitDriver("Name", car);
            UnitDriver driver2 = new UnitDriver("Name2", car2);
            race.AddDriver(driver);
            race.AddDriver(driver2);

            double result = race.CalculateAverageHorsePower();
            double expected = 200;

            Assert.That(result.Equals(expected));
		}

        [Test]
        public void Test4()
        {
			RaceEntry race = new RaceEntry();
			UnitCar car = new UnitCar("Vw", 130, 1900);
			UnitDriver driver = new UnitDriver("Name", car);

			race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();
            });
		}
    }
}