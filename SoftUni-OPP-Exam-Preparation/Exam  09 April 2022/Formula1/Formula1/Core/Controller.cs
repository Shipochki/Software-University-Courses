using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Formula1.Utilities.ExceptionMessages;
using static Formula1.Utilities.OutputMessages;

namespace Formula1.Core
{
	public class Controller : IController
	{
		private IRepository<IPilot> pilots;
		private IRepository<IRace> races;
		private IRepository<IFormulaOneCar> cars;

		public Controller()
		{
			this.pilots = new PilotRepository();
			this.races = new RaceRepository();
			this.cars = new FormulaOneCarRepository();
		}

		public string AddCarToPilot(string pilotName, string carModel)
		{
			IPilot pilot = this.pilots.FindByName(pilotName);
			if (pilot == null || pilot.Car != default)
			{
				throw new InvalidOperationException(string.Format(PilotDoesNotExistOrHasCarErrorMessage, pilotName));
			}

			IFormulaOneCar car = this.cars.FindByName(carModel);
			if (car == null)
			{
				throw new NullReferenceException(string.Format(CarDoesNotExistErrorMessage, carModel));
			}

			pilot.AddCar(car);
			this.cars.Remove(car);
			return string.Format(SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
		}

		public string AddPilotToRace(string raceName, string pilotFullName)
		{
			IRace race = this.races.FindByName(raceName);
			if(race == null)
			{
				throw new NullReferenceException(string.Format(RaceDoesNotExistErrorMessage, raceName));
			}

			IPilot pilot = this.pilots.FindByName(pilotFullName);
			if(pilot == null || pilot.Car == default || !pilot.CanRace || 
				race.Pilots.Any(p => p.FullName == pilot.FullName))
			{
				throw new InvalidOperationException(string.Format(PilotDoesNotExistErrorMessage, pilotFullName));
			}

			race.AddPilot(pilot);
			return string.Format(SuccessfullyAddPilotToRace, pilotFullName, raceName);
		}

		public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
		{
			if(this.cars.FindByName(model) != null)
			{
				throw new InvalidOperationException(string.Format(CarExistErrorMessage, model));
			}

			if(type == nameof(Ferrari))
			{
				IFormulaOneCar car = new Ferrari(model, horsepower, engineDisplacement);
				this.cars.Add(car);
				return string.Format(SuccessfullyCreateCar, type, model);
			}
			else if (type == nameof(Williams))
			{
				IFormulaOneCar car = new Williams(model, horsepower, engineDisplacement);
				this.cars.Add(car);
				return string.Format(SuccessfullyCreateCar, type, model);
			}
			else
			{
				throw new InvalidOperationException(string.Format(InvalidTypeCar, type));
			}
		}

		public string CreatePilot(string fullName)
		{
			if (this.pilots.FindByName(fullName) != null)
			{
				throw new InvalidOperationException(string.Format(PilotExistErrorMessage, fullName));
			}

			IPilot pilot = new Pilot(fullName);
			this.pilots.Add(pilot);
			return string.Format(SuccessfullyCreatePilot, fullName);
		}

		public string CreateRace(string raceName, int numberOfLaps)
		{
			if(this.races.FindByName(raceName) != null)
			{
				throw new InvalidOperationException(string.Format(RaceExistErrorMessage, raceName));
			}

			IRace race = new Race(raceName, numberOfLaps);
			this.races.Add(race);
			return string.Format(SuccessfullyCreateRace, raceName);
		}

		public string PilotReport()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var pilot in this.pilots.Models.OrderByDescending(p => p.NumberOfWins))
			{
				sb.AppendLine(pilot.ToString());
			}

			return sb.ToString().TrimEnd();
		}

		public string RaceReport()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var race in this.races.Models.Where(r => r.TookPlace))
			{
				sb.AppendLine(race.RaceInfo());
				sb.AppendLine();
			}

			return sb.ToString().TrimEnd();
		}

		public string StartRace(string raceName)
		{
			IRace race = this.races.FindByName(raceName);
			if (race == null)
			{
				throw new NullReferenceException(string.Format(RaceDoesNotExistErrorMessage, raceName));
			}

			if(race.Pilots.Count < 3) 
			{
				throw new InvalidOperationException(string.Format(InvalidRaceParticipants, raceName));
			}

			if(race.TookPlace)
			{
				throw new InvalidOperationException(string.Format(RaceTookPlaceErrorMessage, raceName));
			}

			ICollection<IPilot> fastestThree = race.Pilots
				.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
				.Take(3)
				.ToList();

			race.TookPlace = true;

			StringBuilder sb = new StringBuilder();

			int index = 1;
			foreach (var fastest in fastestThree)
			{
				if(index == 1)
				{
					fastest.WinRace();
					sb.AppendLine($"Pilot {fastest.FullName} wins the {raceName} race.");
					index++;
				}
				else if(index == 2)
				{
					sb.AppendLine($"Pilot {fastest.FullName} is second in the {raceName} race.");
					index++;
				}
				else if(index == 3)
				{
					sb.AppendLine($"Pilot {fastest.FullName} is third in the {raceName} race.");
				}
			}

			return sb.ToString().TrimEnd();
		}
	}
}
