using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using static Bakery.Utilities.Messages.ExceptionMessages;
using System.Text;
using System.Linq;

namespace Bakery.Models.Tables
{
	public abstract class Table : ITable
	{
		private ICollection<IBakedFood> FoodOrders;
		private ICollection<IDrink> DrinkOrders;

		public Table(int tableNumber, int capacity, decimal pricePerPerson)
		{
			this.tableNumber = tableNumber;
			Capacity = capacity;
			this.pricePerPerson = pricePerPerson;
			this.FoodOrders = new List<IBakedFood>();
			this.DrinkOrders = new List<IDrink>();
		}

		private int tableNumber;

		public int TableNumber => tableNumber;

		private int capacity;

		public int Capacity
		{
			get { return capacity; }
			private set 
			{ 
				if(value <= 0)
				{
					throw new ArgumentException(InvalidTableCapacity);
				}
				capacity = value; 
			}
		}

		private int numberOfPeople;

		public int NumberOfPeople
		{
			get { return numberOfPeople; }
			private set 
			{
				if(value <= 0)
				{
					throw new ArgumentException(InvalidNumberOfPeople);
				}
				numberOfPeople = value;
			}
		}

		private decimal pricePerPerson;

		public decimal PricePerPerson => pricePerPerson;

		private bool isReserved;

		public bool IsReserved => isReserved;


		public decimal Price => numberOfPeople * pricePerPerson;


		public void Clear()
		{
			this.FoodOrders = new List<IBakedFood>();
			this.DrinkOrders = new List<IDrink>();
			this.isReserved = false;
			this.numberOfPeople = 0;
		}

		public decimal GetBill()
		{
			decimal sum = this.FoodOrders.Sum(f => f.Price);
			sum += this.DrinkOrders.Sum(d => d.Price);
			sum += this.Price;
			return sum;
		}

		public string GetFreeTableInfo()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Table: {this.tableNumber}");
			sb.AppendLine($"Type: {this.GetType().Name}");
			sb.AppendLine($"Capacity: {this.capacity}");
			sb.AppendLine($"Price per Person: {this.pricePerPerson}");

			return sb.ToString().TrimEnd();
		}

		public void OrderDrink(IDrink drink)
		{
			this.DrinkOrders.Add(drink);
		}

		public void OrderFood(IBakedFood food)
		{
			this.FoodOrders.Add(food);
		}

		public void Reserve(int numberOfPeople)
		{
			NumberOfPeople = numberOfPeople;
			isReserved = true;
		}
	}
}
