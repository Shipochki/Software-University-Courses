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
			Stamina = stamina;
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

		private int stamina;

		public int Stamina
		{
			get { return stamina; }
			private set { stamina = value; }
		}

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

		public void Exercise()
		{
			if(this.GetType().Name == nameof(Boxer))
			{
				if (this.stamina + 15 > 100)
				{
					this.stamina = 100;
					throw new ArgumentException(InvalidStamina);
				}
				else
				{
					this.stamina += 15;
				}
			}
			else if(this.GetType().Name == nameof(Weightlifter))
			{
				if(this.stamina + 10 > 100)
				{
					this.stamina = 100;
					throw new ArgumentException(InvalidStamina);
				}
				else
				{
					this.stamina += 10;
				}
			}
		}
	}
}
