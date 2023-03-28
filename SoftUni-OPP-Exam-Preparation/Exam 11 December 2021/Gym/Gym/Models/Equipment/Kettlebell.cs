using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
	public class Kettlebell : Equipment
	{
		private const double initalWeight = 10000;
		private const decimal initalPrice = 80;
		public Kettlebell() : base(initalWeight, initalPrice)
		{
		}
	}
}
