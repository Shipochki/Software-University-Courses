namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void Test1()
        {
            Aquarium aquarium = new Aquarium("Aquarium", 1);

            Assert.That(aquarium.Name.Equals("Aquarium"));
            Assert.That(aquarium.Capacity.Equals(1));

            Assert.Throws<ArgumentNullException>(() =>
            {
				Aquarium aquarium = new Aquarium(null, 1);
			});

			Assert.Throws<ArgumentException>(() =>
			{
				Aquarium aquarium = new Aquarium("Aquarium", -1);
			});
		}

        [Test]
        public void Test2()
        {
			Aquarium aquarium = new Aquarium("Aquarium", 1);
            Fish fish = new Fish("Fish");

            aquarium.Add(fish);
            Assert.That(aquarium.Count.Equals(1));

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
            });
		}

		[Test]
		public void Test3()
		{
			Aquarium aquarium = new Aquarium("Aquarium", 1);
			Fish fish = new Fish("Fish");

			aquarium.Add(fish);
            aquarium.RemoveFish("Fish");
			Assert.That(aquarium.Count.Equals(0));

			Assert.Throws<InvalidOperationException>(() =>
			{
				aquarium.RemoveFish("Fish");
			});
		}

		[Test]
		public void Test4()
		{
			Aquarium aquarium = new Aquarium("Aquarium", 1);
			Fish fish = new Fish("Fish");

			aquarium.Add(fish);
			Fish result = aquarium.SellFish("Fish");

			Assert.That(result.Equals(fish));
			Assert.That(result.Available.Equals(false));

			Assert.Throws<InvalidOperationException>(() =>
			{
				aquarium.SellFish("Empty");
			});
		}

		[Test]
		public void Test5()
		{
			Aquarium aquarium = new Aquarium("Aquarium", 1);
			Fish fish = new Fish("Fish");

			aquarium.Add(fish);
			string expected = $"Fish available at Aquarium: Fish";
			string result = aquarium.Report();

			Assert.That(result.Equals(expected));
		}
	}
}
