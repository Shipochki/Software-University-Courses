using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers.Models
{
    public class StreetRacer : Racer
    {
        private const int initalDrivingExperience = 10;
        private const string initalRacingBegavior = "aggressive";
        public StreetRacer(string username, ICar car)
            : base(username, initalRacingBegavior, initalDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            base.drivingExperience += 5;
        }
    }
}
