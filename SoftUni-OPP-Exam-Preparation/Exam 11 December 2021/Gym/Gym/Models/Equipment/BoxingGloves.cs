﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
	public class BoxingGloves : Equipment
	{
		private const double initalWeight = 227;
		private const decimal initalPrice = 120;
		public BoxingGloves() : base(initalWeight, initalPrice)
		{
		}
	}
}
