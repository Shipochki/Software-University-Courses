using Bakery.Models.BakedFoods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using static Bakery.Utilities.Messages.ExceptionMessages;

namespace Bakery.Models.BakedFoods
{
	public abstract class BakedFood : IBakedFood
	{
		public BakedFood(string name, int portion, decimal price)
		{
			Name = name;
			Portion = portion;
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
				if(value <= 0)
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

		public override string ToString()
		{
			return $"{this.Name}: {this.Portion}g - {this.Price:f2}";
		}
	}
}
