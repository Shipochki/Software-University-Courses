namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	[TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Test1()
        {
            Bag bag = new Bag();
            Present present = new Present("Present", 1);

            string expected = $"Successfully added present {present.Name}.";
            string result = bag.Create(present);

            Assert.That(result.Equals(expected));

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(null);
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
		}

        [Test]
        public void Test2()
        {
            Bag bag = new Bag();
			Present present = new Present("Present", 1);
			Present present1 = new Present("Present1", 2);
			bag.Create(present);

            bool result = bag.Remove(present);

            Assert.That(result.Equals(true));

            bool result1 = bag.Remove(present1);

            Assert.That(result1.Equals(false));
		}

        [Test]
		public void Test3()
		{
			Bag bag = new Bag();
			Present present = new Present("Present", 1);
			Present present1 = new Present("Present1", 2);
			bag.Create(present);
            bag.Create(present1);

            Present result = bag.GetPresentWithLeastMagic();

            Assert.That(result.Equals(present));
		}

		[Test]
		public void Test4()
		{
			Bag bag = new Bag();
			Present present = new Present("Present", 1);
			Present present1 = new Present("Present1", 2);
			bag.Create(present);
			bag.Create(present1);

			Present result = bag.GetPresent("Present");

			Assert.That(result.Equals(present));
		}

		[Test]
		public void Test5()
		{
			Bag bag = new Bag();
			Present present = new Present("Present", 1);
			Present present1 = new Present("Present1", 2);
			bag.Create(present);
			bag.Create(present1);

			IReadOnlyCollection<Present> result = bag.GetPresents();

			Assert.That(result.First().Equals(present));
		}
	}
}
