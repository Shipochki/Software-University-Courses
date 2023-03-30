using CarRacing.Core.Contracts;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Cars.Models;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Maps.Models;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Repositories.Models;
using System;
using static CarRacing.Utilities.Messages.ExceptionMessages;
using static CarRacing.Utilities.Messages.OutputMessages;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Racers.Models;
using System.Linq;

namespace CarRacing.Core
{
	public class Controller : IController
	{
		IRepository<ICar> cars;
		IRepository<IRacer> racers;
		IMap map;

		public Controller()
		{
			this.cars = new CarRepository();
			this.racers = new RacerRepository();
			this.map = new Map();
		}

		public string AddCar(string type, string make, string model, string VIN, int horsePower)
		{
			ICar car = null;
			if (type == nameof(SuperCar))
			{
				car = new SuperCar(make, model, VIN, horsePower);
			}
			else if (type == nameof(TunedCar))
			{
				car = new TunedCar(make, model, VIN, horsePower);
			}
			else
			{
				throw new ArgumentException(InvalidCarType);
			}

			this.cars.Add(car);
			return string.Format(SuccessfullyAddedCar, make, model, VIN);
		}

		public string AddRacer(string type, string username, string carVIN)
		{
			IRacer racer = null;
			ICar car = this.cars.FindBy(carVIN);

			if (car == null) 
			{
				throw new ArgumentException(CarCannotBeFound);
			}

			if (type == nameof(ProfessionalRacer))
			{
				racer = new ProfessionalRacer(username, car);
			}
			else if(type == nameof(StreetRacer))
			{
				racer = new StreetRacer(username, car);
			}
			else
			{
				throw new ArgumentException(InvalidRacerType);
			}

			this.racers.Add(racer);
			return string.Format(SuccessfullyAddedRacer, username);
		}

		public string BeginRace(string racerOneUsername, string racerTwoUsername)
		{
			IRacer racerOne = this.racers.FindBy(racerOneUsername);
			IRacer racerTwo = this.racers.FindBy(racerTwoUsername);
			if(racerOne == null)
			{
				throw new ArgumentException(string.Format(RacerCannotBeFound, racerOneUsername));
			}
			else if(racerTwo == null)
			{
				throw new ArgumentException(string.Format(RacerCannotBeFound, racerTwoUsername));
			}

			return map.StartRace(racerOne, racerTwo);
		}

		public string Report()
		{
			StringBuilder sb = new StringBuilder();
			List<IRacer> racers = this.racers
				.Models
				.OrderByDescending(r => r.DrivingExperience)
				.ThenBy(r => r.Username)
				.ToList();

			foreach (var racer in racers)
			{
				sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
				sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
				sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
				sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
