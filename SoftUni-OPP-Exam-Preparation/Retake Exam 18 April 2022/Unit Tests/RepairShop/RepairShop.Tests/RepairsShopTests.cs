using NUnit.Framework;
using System;
using System.Text;

namespace RepairShop.Tests
{
	public class Tests
	{
		public class RepairsShopTests
		{
			[Test]
			public void Test1()
			{
				Garage garage = new Garage("Garage", 1);
				Car car = new Car("vw", 2);
				Car car2 = new Car("fg", 2);
				garage.AddCar(car);

				Assert.Throws<InvalidOperationException>(() =>
				{
					garage.AddCar(car2);
				});

				Assert.Throws<InvalidOperationException>(() =>
				{
					garage.FixCar(car2.CarModel);
				});

				Assert.Throws<InvalidOperationException>(() =>
				{
					garage.RemoveFixedCar();
				});
			}

			[Test]
			public void Test2()
			{
				Garage garage = new Garage("Garage", 1);
				Car car = new Car("vw", 2);
				garage.AddCar(car);

				Car fixedCar = garage.FixCar("vw");
				Assert.That(fixedCar.CarModel.Equals(car.CarModel));
				Assert.That(fixedCar.NumberOfIssues.Equals(0));

				int removedCars = garage.RemoveFixedCar();
				Assert.That(removedCars.Equals(1));
			}

			[Test]
			public void Test3()
			{
				Garage garage = new Garage("Garage", 1);

				Assert.That(garage.Name.Equals("Garage"));

				Assert.Throws<ArgumentNullException>(() =>
				{
					Garage garage = new Garage(null, 3);
				});
			}

			[Test]
			public void Test4()
			{
				Garage garage = new Garage("Garage", 1);
				Car car = new Car("vw", 2);
				garage.AddCar(car);

				Assert.That(garage.MechanicsAvailable.Equals(1));

				Assert.Throws<ArgumentException>(() =>
				{
					Garage garage = new Garage("Garage", 0);
				});

				Assert.That(garage.CarsInGarage.Equals(1));
			}

			[Test]
			public void Test5()
			{
				Garage garage = new Garage("Garage", 1);
				Car car2 = new Car("fg", 2);

				garage.AddCar(car2);
				string report = $"There are 1 which are not fixed: fg.";
				string result = garage.Report();
				Assert.That(result.Equals(report));
			}
		}
	}
}