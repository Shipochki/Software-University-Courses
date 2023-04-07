using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer = new Computer("manu", "model", 1500);

            manager.AddComputer(computer);

            Assert.That(manager.Count.Equals(1));
            Assert.That(manager.Computers.First().Equals(computer));
        }

		[Test]
		public void Test11()
		{
			ComputerManager manager = new ComputerManager();
			Computer computer = new Computer("manu", "model", 1500);

			manager.AddComputer(computer);

			Assert.Throws<ArgumentException>(() =>
			{
				manager.AddComputer(computer);
			});

			Assert.Throws<ArgumentNullException>(() =>
			{
				manager.AddComputer(null);
			});
		}

		[Test]
		public void Test2()
		{
			ComputerManager manager = new ComputerManager();
			Computer computer = new Computer("manu", "model", 1500);

			manager.AddComputer(computer);
            Computer result = manager.RemoveComputer("manu", "model");

            Assert.That(result.Equals(computer));

			Assert.Throws<ArgumentNullException>(() =>
			{
				manager.RemoveComputer(null, "model");
			});

			Assert.Throws<ArgumentNullException>(() =>
			{
				manager.RemoveComputer("manu", null);
			});

			Assert.Throws<ArgumentException>(() =>
			{
				manager.RemoveComputer("empty", "empty");
			});
		}

		[Test]
		public void Test3()
		{
			ComputerManager manager = new ComputerManager();
			Computer computer = new Computer("manu", "model", 1500);

			manager.AddComputer(computer);
			Computer result = manager.GetComputer("manu", "model");

			Assert.That(result.Equals(computer));
		}

		[Test]
		public void Test4()
		{
			ComputerManager manager = new ComputerManager();
			Computer computer = new Computer("manu", "model", 1500);

			Assert.Throws<ArgumentNullException>(() =>
			{
				manager.GetComputer(null, "model");
			});

			Assert.Throws<ArgumentNullException>(() =>
			{
				manager.GetComputer("menu", null);
			});

			Assert.Throws<ArgumentException>(() =>
			{
				manager.GetComputer("empty", "empty");
			});
		}

		[Test]
		public void Test5()
		{
			ComputerManager manager = new ComputerManager();
			Computer computer = new Computer("manu", "model", 1500);

			manager.AddComputer(computer);

			ICollection<Computer> result = manager.GetComputersByManufacturer("manu");

			Assert.That(result.First().Equals(computer));

			Assert.Throws<ArgumentNullException>(() =>
			{
				manager.GetComputersByManufacturer(null);
			});
		}
	}
}