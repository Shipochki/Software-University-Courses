using System;
using static Gym.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
	public class Weightlifter : Athlete
	{
		private const int initalStamina = 50;
		public Weightlifter(string fullName, string motivation, int numberOfMedals)
			: base(fullName, motivation, numberOfMedals, initalStamina)
		{
		}

		public override void Exercise()
		{
			if (base.stamina + 10 > 100)
			{
				base.stamina = 100;
				throw new ArgumentException(InvalidStamina);
			}
			else
			{
				base.stamina += 10;
			}
		}
	}
}
