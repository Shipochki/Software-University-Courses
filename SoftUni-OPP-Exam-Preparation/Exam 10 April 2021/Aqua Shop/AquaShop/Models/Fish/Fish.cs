using AquaShop.Models.Fish.Contracts;
using System;
using static AquaShop.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
	public class Fish : IFish
	{
		public Fish(string name, string species, decimal price)
		{
			Name = name;
			Species = species;
			Price = price;
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set 
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidFishName);
				}
				name = value; 
			}
		}

		private string species;

		public string Species
		{
			get { return species; }
			private set 
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidFishSpecies);
				}
				species = value; 
			}
		}

		protected int size;

		public int Size => size;

		private decimal price;

		public decimal Price
		{
			get { return price; }
			private set 
			{ 
				if(value <= 0)
				{
					throw new ArgumentException(InvalidFishPrice);
				}
				price = value; 
			}
		}


		public virtual void Eat(){}
	}
}
