using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using static CarRacing.Utilities.Messages.OutputMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps.Models
{
	public class Map : IMap
	{
		public string StartRace(IRacer racerOne, IRacer racerTwo)
		{
			if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
			{
				return string.Format(RaceCannotBeCompleted);
			}
			else if (!racerOne.IsAvailable())
			{
				return string.Format(OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
			}
			else if (!racerTwo.IsAvailable())
			{
				return string.Format(OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
			}

			double racingBehaviorRacerOne = 1.2;
			if (racerOne.RacingBehavior == "aggressive")
			{
				racingBehaviorRacerOne = 1.1;
			}
			double racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorRacerOne;

			double racingBehaviorRacerTwo = 1.2;
			if (racerTwo.RacingBehavior == "aggressive")
			{
				racingBehaviorRacerTwo = 1.1;
			}
			double racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorRacerTwo;

			racerOne.Race();
			racerTwo.Race();

			IRacer winner = racerOne;
			if (racerTwoChance > racerOneChance)
			{
				winner = racerTwo;
			}

			return string.Format(RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
		}
	}
}
