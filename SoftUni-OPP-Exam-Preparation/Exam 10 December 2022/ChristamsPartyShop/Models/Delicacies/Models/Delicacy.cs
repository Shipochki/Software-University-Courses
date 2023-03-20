using ChristmasPastryShop.Models.Delicacies.Contracts;
using System;
using static ChristmasPastryShop.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
	public class Delicacy : IDelicacy
	{
		public Delicacy(string delicacyName, double price)
		{
			Name = delicacyName;
			Price = price;
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set 
			{ 
				if(string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(NameNullOrWhitespace);
				}

				name = value; 
			}
		}

		private double price;

		public double Price
		{
			get { return price; }
			private set { price = value; }
		}

		public override string ToString()
		{
			return $"{this.name} - {this.price:f2} lv";
		}
	}
}
