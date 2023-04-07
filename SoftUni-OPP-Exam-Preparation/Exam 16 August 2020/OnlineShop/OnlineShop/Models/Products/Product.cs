using System;
using static OnlineShop.Common.Constants.ExceptionMessages;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
	public abstract class Product : IProduct
	{
		public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
		{
			Id = id;
			Manufacturer = manufacturer;
			Model = model;
			Price = price;
			OverallPerformance = overallPerformance;
		}

		private int id;

		public int Id
		{
			get { return id; }
			private set 
			{ 
				if(value <= 0)
				{
					throw new ArgumentException(InvalidProductId);
				}
				id = value;
			}
		}

		private string manufacturer;

		public string Manufacturer
		{
			get { return manufacturer; }
			private set 
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidManufacturer);
				}
				manufacturer = value; 
			}
		}

		private string model;

		public string Model
		{
			get { return model; }
			private set 
			{ 
				if(string.IsNullOrEmpty(value))
				{ 
					throw new ArgumentException(InvalidModel); 
				}
				model = value; 
			}
		}

		protected decimal price;

		public virtual decimal Price
		{
			get { return price; }
			private set 
			{ 
				if(value <= 0)
				{
					throw new ArgumentException(InvalidPrice);
				}
				price = value; 
			}
		}

		protected double overallPerformance;

		public virtual double OverallPerformance
		{
			get { return overallPerformance; }
			private set 
			{ 
				if(value <= 0)
				{
					throw new ArgumentException(InvalidOverallPerformance);
				}
				overallPerformance = value; 
			}
		}

		public override string ToString()
		{
			return $"Overall Performance: {this.overallPerformance:f2}. Price: {this.price:f2} - {this.GetType().Name}: {this.manufacturer} {this.model} (Id: {this.id})";
		}
	}
}
