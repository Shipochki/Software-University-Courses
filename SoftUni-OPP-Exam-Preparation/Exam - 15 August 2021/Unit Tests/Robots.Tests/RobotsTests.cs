namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void Test1()
        {
            RobotManager robotManager = new RobotManager(1);

            Assert.That(robotManager.Capacity.Equals(1));
			Assert.That(robotManager.Count.Equals(0));

            Assert.Throws<ArgumentException>(() =>
            {
				RobotManager robotManager = new RobotManager(-1);
			});
		}

        [Test] 
        public void Test2()
        {
			RobotManager robotManager = new RobotManager(1);
            Robot robot = new Robot("Robot", 10);
            Robot robot1 = new Robot("Robot1", 10);

			Assert.That(robot.Name.Equals("Robot"));

            robotManager.Add(robot);
            Assert.That(robotManager.Count.Equals(1));

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot);
            });

			Assert.Throws<InvalidOperationException>(() =>
			{
				robotManager.Add(robot1);
			});
		}

		[Test]
		public void Test3()
		{
			RobotManager robotManager = new RobotManager(1);
			Robot robot = new Robot("Robot", 10);
			Robot robot1 = new Robot("Robot1", 10);

			robotManager.Add(robot);
			robotManager.Remove("Robot");

			Assert.That(robotManager.Count.Equals(0));

			robotManager.Add(robot);

			Assert.Throws<InvalidOperationException>(() =>
			{
				robotManager.Remove("Robot1");
			});
		}

		[Test]
		public void Test4()
		{
			RobotManager robotManager = new RobotManager(1);
			Robot robot = new Robot("Robot", 10);
			Robot robot1 = new Robot("Robot1", 10);

			robotManager.Add(robot);
			robotManager.Work("Robot", "work", 5);

			Assert.That(robot.Battery.Equals(5));

			Assert.Throws<InvalidOperationException>(() =>
			{
				robotManager.Work("Robot1", "work", 5);
			});

			Assert.Throws<InvalidOperationException>(() =>
			{
				robotManager.Work("Robot", "work", 11);
			});
		}

		[Test]
		public void Test5()
		{
			RobotManager robotManager = new RobotManager(1);
			Robot robot = new Robot("Robot", 10);
			Robot robot1 = new Robot("Robot1", 10);

			robotManager.Add(robot);
			robotManager.Work("Robot", "work", 5);
			robotManager.Charge("Robot");

			Assert.That(robot.Battery.Equals(10));

			Assert.Throws<InvalidOperationException>(() =>
			{
				robotManager.Charge("Robot1");
			});
		}

		[Test]
		public void Test6()
		{

		}
	}
}
