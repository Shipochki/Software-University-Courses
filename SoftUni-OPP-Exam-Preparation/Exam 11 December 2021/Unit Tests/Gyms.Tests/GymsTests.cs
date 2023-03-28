using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void Test1()
        {
            Gym gym = new Gym("Gym", 1);

            Assert.That(gym.Name.Equals("Gym"));
            Assert.That(gym.Capacity.Equals(1));

            Assert.Throws<ArgumentNullException>(() =>
            {
				Gym gym = new Gym(null, 1);
			});

            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Gym", -1);
            });
        }

        [Test]
        public void Test2()
        {
			Gym gym = new Gym("Gym", 1);
            Athlete athlete = new Athlete("Niki");

            gym.AddAthlete(athlete);
            Assert.That(gym.Count.Equals(1));

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete);
            });
		}

		[Test]
		public void Test3()
		{
			Gym gym = new Gym("Gym", 1);
			Athlete athlete = new Athlete("Niki");

			gym.AddAthlete(athlete);
            gym.RemoveAthlete("Niki");
			Assert.That(gym.Count.Equals(0));

			Assert.Throws<InvalidOperationException>(() =>
			{
				gym.RemoveAthlete("Niki");
			});
		}

		[Test]
		public void Test4()
		{
			Gym gym = new Gym("Gym", 1);
			Athlete athlete = new Athlete("Niki");

			gym.AddAthlete(athlete);
			Athlete result = gym.InjureAthlete("Niki");
			Assert.That(result.Equals(athlete));
			Assert.That(result.IsInjured.Equals(true));

			Assert.Throws<InvalidOperationException>(() =>
			{
				gym.InjureAthlete("Pesho");
			});
		}

		[Test]
		public void Test5()
		{
			Gym gym = new Gym("Gym", 1);
			Athlete athlete = new Athlete("Niki");

			gym.AddAthlete(athlete);
			string result = gym.Report();
			string expected = $"Active athletes at Gym: Niki";

			Assert.That(result.Equals(expected));
		}
	}
}
