using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using static EasterRaces.Utilities.Messages.ExceptionMessages;
using static EasterRaces.Utilities.Messages.OutputMessages;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races.Entities;
using System.Net.Http.Headers;
using System.Linq;

namespace EasterRaces.Core.Entities
{
	public class ChampionshipController : IChampionshipController
	{
		private IRepository<ICar> cars;
		private IRepository<IDriver> drivers;
		private IRepository<IRace> races;

		public ChampionshipController()
		{
			this.cars = new CarRepository();
			this.drivers = new DriverRepository();
			this.races = new RaceRepository();
		}

		public string AddCarToDriver(string driverName, string carModel)
		{
			IDriver driver = this.drivers.GetByName(driverName);
			if (driver == null)
			{
				throw new InvalidOperationException(string.Format(DriverNotFound, driverName));
			}

			ICar car = this.cars.GetByName(carModel);
			if(car == null)
			{
				throw new InvalidOperationException(string.Format(CarNotFound, carModel));
			}

			driver.AddCar(car);
			return string.Format(CarAdded, driverName, carModel);
		}

		public string AddDriverToRace(string raceName, string driverName)
		{
			IRace race = this.races.GetByName(raceName);
			if(race == null)
			{
				throw new InvalidOperationException(string.Format(RaceNotFound, raceName));
			}

			IDriver driver = this.drivers.GetByName(driverName);
			if (driver == null)
			{
				throw new InvalidOperationException(string.Format(DriverNotFound, driverName));
			}

			race.AddDriver(driver);
			return string.Format(DriverAdded, driverName, raceName);
		}

		public string CreateCar(string type, string model, int horsePower)
		{
			if(this.cars.GetByName(model) != null)
			{
				throw new ArgumentException(string.Format(CarExists, model));
			}

			ICar car;
			if(type == "Muscle")
			{
				car = new MuscleCar(model, horsePower);
			}
			else
			{
				car = new SportsCar(model, horsePower);
			}

			this.cars.Add(car);
			return string.Format(CarCreated, car.GetType().Name, model);
		}

		public string CreateDriver(string driverName)
		{
			if(this.drivers.GetByName(driverName) != null)
			{
				throw new ArgumentException(string.Format(DriversExists, driverName));
			}

			IDriver driver = new Driver(driverName);
			this.drivers.Add(driver);
			return string.Format(DriverCreated, driverName);
		}

		public string CreateRace(string name, int laps)
		{
			if(this.races.GetByName(name) != null)
			{
				throw new InvalidOperationException(string.Format(RaceExists, name));
			}

			IRace race = new Race(name, laps);
			this.races.Add(race);
			return string.Format(RaceCreated, name);
		}

		public string StartRace(string raceName)
		{
			IRace race = this.races.GetByName(raceName);
			if (race == null)
			{
				throw new InvalidOperationException(string.Format(RaceNotFound, raceName));
			}

			if(race.Drivers.Count < 3)
			{
				throw new InvalidOperationException(string.Format(RaceInvalid, raceName, 3));
			}

			List<IDriver> topThree = race
				.Drivers
				.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
				.Take(3)
				.ToList();

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Driver {topThree[0].Name} wins {raceName} race.");
			sb.AppendLine($"Driver {topThree[1].Name} is second in {raceName} race.");
			sb.AppendLine($"Driver {topThree[2].Name} is third in {raceName} race.");

			this.races.Remove(race);

			return sb.ToString().TrimEnd();
		}
	}
}
