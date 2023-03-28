using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
	public class Equipment : IEquipment
	{
		public Equipment(double weight, decimal price)
		{
			this.weight = weight;
			this.price = price;
		}

		private double weight;

		public double Weight => weight;

		private decimal price;

		public decimal Price => price;

	}
}
