using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers.Models
{
    public class ProfessionalRacer : Racer
    {
        private const int initalDrivingExperience = 30;
        private const string initalRacingBegavior = "strict";
        public ProfessionalRacer(string username, ICar car)
            : base(username, initalRacingBegavior, initalDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            base.drivingExperience += 10;
        }
    }
}
