using EasterRaces.Models.Cars.Contracts;
using System;
using static EasterRaces.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
	public abstract class Car : ICar
	{
		private int minHorsePower;
		private int maxHorsePower;

		public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
		{
			Model = model;
			HorsePower = horsePower;
			this.cubicCentimeters = cubicCentimeters;
			this.minHorsePower = minHorsePower;
			this.maxHorsePower = maxHorsePower;
		}

		private string model;

		public string Model
		{
			get { return model; }
			private set 
			{
				if (string.IsNullOrEmpty(value) || value.Length < 4)
				{
					throw new ArgumentException(string.Format(InvalidModel, value, 4));
				}
				model = value; 
			}
		}

		private int horsePower;

		public int HorsePower
		{
			get { return horsePower; }
			private set 
			{ 
				if(value < minHorsePower || value > maxHorsePower)
				{
					throw new ArgumentException(string.Format(InvalidHorsePower, value));
				}
				horsePower = value; 
			}
		}

		protected double cubicCentimeters;

		public double CubicCentimeters => cubicCentimeters;


		public double CalculateRacePoints(int laps)
		{
			return cubicCentimeters / horsePower * laps;
		}
	}
}
