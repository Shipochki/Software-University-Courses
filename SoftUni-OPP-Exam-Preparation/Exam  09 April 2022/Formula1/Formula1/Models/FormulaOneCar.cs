using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Formula1.Utilities.ExceptionMessages;

namespace Formula1.Models
{
	public class FormulaOneCar : IFormulaOneCar
	{
		public FormulaOneCar(string model, int horsepower, double engineDisplacement)
		{
			Model = model;
			Horsepower = horsepower;
			EngineDisplacement = engineDisplacement;
		}

		private string model;

		public string Model
		{
			get { return model; }
			private set
			{
				if (string.IsNullOrEmpty(value) || value.Length < 3)
				{
					throw new ArgumentException(string.Format(InvalidF1CarModel, value));
				}
				model = value;
			}
		}

		private int horsepower;

		public int Horsepower
		{
			get { return horsepower; }
			private set
			{
				if (value < 900 || value > 1050)
				{
					throw new ArgumentException(string.Format(InvalidF1HorsePower, value));
				}
				horsepower = value;
			}
		}

		private double engineDisplacement;

		public double EngineDisplacement
		{
			get { return engineDisplacement; }
			private set
			{
				if (value < 1.6 || value > 2)
				{
					throw new ArgumentException(string.Format(InvalidF1EngineDisplacement, value));
				}
				engineDisplacement = value;
			}
		}


		public double RaceScoreCalculator(int laps)
		{
			return this.engineDisplacement / horsepower * laps;
		}
	}
}
