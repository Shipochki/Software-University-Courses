using Bakery.Models.Drinks.Contracts;
using System;
using static Bakery.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
	public abstract class Drink : IDrink
	{
		public Drink(string name, int portion, decimal price, string brand)
		{
			Name = name;
			Portion = portion;
			Price = price;
			Brand = brand;
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidName);
				}
				name = value;
			}
		}

		private int portion;

		public int Portion
		{
			get { return portion; }
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException(InvalidPortion);
				}
				portion = value;
			}
		}

		private decimal price;

		public decimal Price
		{
			get { return price; }
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException(InvalidPrice);
				}
				price = value;
			}
		}

		private string brand;

		public string Brand
		{
			get { return brand; }
			private set 
			{ 
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidBrand);
				}
				brand = value; 
			}
		}

		public override string ToString()
		{
			return $"{this.Name} {this.Brand} - {this.Portion}ml - {this.Price:f2}lv";
		}
	}
}
