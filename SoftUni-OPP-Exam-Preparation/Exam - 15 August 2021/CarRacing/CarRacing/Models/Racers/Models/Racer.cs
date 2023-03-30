using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using static CarRacing.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers.Models
{
    public class Racer : IRacer
    {
        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        private string username;

        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidRacerName);
                }
                username = value;
            }
        }

        private string racingBehavior;

        public string RacingBehavior
        {
            get { return racingBehavior; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidRacerBehavior);
                }
                racingBehavior = value;
            }
        }

        protected int drivingExperience;

        public int DrivingExperience
        {
            get { return drivingExperience; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(InvalidRacerDrivingExperience);
                }
                drivingExperience = value;
            }
        }

        private ICar car;

        public ICar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(InvalidRacerCar);
                }
                car = value;
            }
        }

        public bool IsAvailable()
        {
            if (car.FuelAvailable - car.FuelConsumptionPerRace > 0)
            {
                return true;
            }

            return false;
        }

        public virtual void Race()
        {
            car.Drive();
        }
    }
}
