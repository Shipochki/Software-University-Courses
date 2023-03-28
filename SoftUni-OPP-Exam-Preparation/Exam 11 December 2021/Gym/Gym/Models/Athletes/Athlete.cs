using Gym.Models.Athletes.Contracts;
using System;
using static Gym.Utilities.Messages.ExceptionMessages;

namespace Gym.Models.Athletes
{
	public class Athlete : IAthlete
	{
		public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
		{
			FullName = fullName;
			Motivation = motivation;
			NumberOfMedals = numberOfMedals;
			this.stamina = stamina;
		}

		private string fullName;

		public string FullName
		{
			get { return fullName; }
			private set 
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidAthleteName);
				}
				fullName = value; 
			}
		}

		private string motivation;

		public string Motivation
		{
			get { return motivation; }
			private set 
			{ 
				if(string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidAthleteMotivation);
				}
				motivation = value; 
			}
		}

		protected int stamina;

		public int Stamina => this.stamina;

		private int numberOfMedals;

		public int NumberOfMedals
		{
			get { return numberOfMedals; }
			private set 
			{
				if(value < 0)
				{
					throw new ArgumentException(InvalidAthleteMedals);
				}
				numberOfMedals = value; 
			}
		}

		public virtual void Exercise() { }
	}
}
