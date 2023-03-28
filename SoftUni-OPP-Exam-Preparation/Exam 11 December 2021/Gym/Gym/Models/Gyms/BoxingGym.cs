using Gym.Models.Athletes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
	public class BoxingGym : Gym
	{
		private const int initalCapacity = 15;
		public BoxingGym(string name) : base(name, initalCapacity)
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
