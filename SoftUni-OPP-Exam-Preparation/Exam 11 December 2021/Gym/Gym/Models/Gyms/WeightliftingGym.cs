﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
	public class WeightliftingGym : Gym
	{
		private const int initalCapacity = 20;
		public WeightliftingGym(string name) : base(name, initalCapacity)
		{
		}

		public override void Exercise()
		{
			foreach (var athlete in this.athletes)
			{
				athlete.Exercise();
			}
		}
	}
}
