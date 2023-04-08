using NUnit.Framework;
using System.Linq;

namespace RobotFactory.Tests
{
	public class Tests
	{

		[Test]
		public void Test1()
		{
			Factory factory = new Factory("Factory", 1);
			Robot robot = new Robot("robot", 100, 5);

			Assert.That(factory.Name.Equals("Factory"));
			Assert.That(factory.Capacity.Equals(1));

			string result = factory.ProduceRobot("robot", 100, 5);
			string expected = $"Produced --> {robot}";

			Assert.That(result.Equals(expected));
			Assert.That(factory.Robots.Count.Equals(1));
		}

		[Test]
		public void Test2()
		{
			Factory factory = new Factory("Factory", 1);
			Robot robot = new Robot("robot", 100, 5);
			factory.ProduceRobot("robot2", 1002, 54);

			string result = factory.ProduceRobot("robot", 100, 5);
			string expected = $"The factory is unable to produce more robots for this production day!";

			Assert.That(result.Equals(expected));

		}

		[Test]
		public void Test3()
		{
			Factory factory = new Factory("Factory", 1);
			Supplement supplement = new Supplement("robot", 5);
			factory.ProduceRobot("robot2", 1002, 54);

			string result = factory.ProduceSupplement("robot", 5);
			string expected = supplement.ToString();

			Assert.That(result.Equals(expected));
			Assert.That(factory.Supplements.Count.Equals(1));

		}

		[Test]
		public void Test4()
		{
			Factory factory = new Factory("Factory", 2);
			Robot robot = new Robot("robot2", 1002, 5);
			Supplement supplement = new Supplement("sup", 5);

			factory.ProduceRobot("robot2", 1002, 5);
			factory.ProduceSupplement("sup", 5);

			bool result = factory.UpgradeRobot(robot, supplement);
			bool expected = true;

			Assert.That(result.Equals(expected));
			Assert.That(robot.Supplements.Count.Equals(1));

			Robot error = new Robot("rob", 100, 20);
			bool result2 = factory.UpgradeRobot(error, supplement);
			bool expected2 = false;

			Assert.That(result2.Equals(expected2));

			factory.ProduceRobot("rob", 100, 20);
			bool result3 = factory.UpgradeRobot(error, supplement);
			bool expected3 = false;

			Assert.That(result3.Equals(expected3));
		}

		[Test]
		public void Test5()
		{
			Factory factory = new Factory("Factory", 2);
			Robot robot = new Robot("robot2", 1002, 5);
			Supplement supplement = new Supplement("sup", 5);

			factory.ProduceRobot("robot2", 1002, 5);
			factory.ProduceSupplement("sup", 5);

			Robot result = factory.SellRobot(1002);
			Robot expected = factory.Robots.First();

			Assert.That(result.Equals(expected));

			Assert.IsNull(factory.SellRobot(900));
		}
	}
}