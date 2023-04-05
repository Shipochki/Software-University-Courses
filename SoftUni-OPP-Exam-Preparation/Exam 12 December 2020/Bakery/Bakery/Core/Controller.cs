using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Bakery.Utilities.Messages.OutputMessages;

namespace Bakery.Core
{
	public class Controller : IController
	{
		ICollection<IBakedFood> bakedFoods;
		ICollection<IDrink> drinks;
		ICollection<ITable> tables;
		private decimal totalIncome;

		public Controller()
		{
			this.bakedFoods = new List<IBakedFood>();
			this.drinks = new List<IDrink>();
			this.tables = new List<ITable>();
			this.totalIncome = 0;
		}

		public string AddDrink(string type, string name, int portion, string brand)
		{
			IDrink drink;
			if (type == nameof(Tea))
			{
				drink = new Tea(name, portion, brand);
			}
			else
			{
				drink = new Water(name, portion, brand);
			}

			this.drinks.Add(drink);
			return string.Format(DrinkAdded, name, brand);
		}

		public string AddFood(string type, string name, decimal price)
		{
			IBakedFood food;
			if(type == nameof(Bread))
			{
				food = new Bread(name, price);
			}
			else
			{
				food = new Cake(name, price);
			}

			this.bakedFoods.Add(food);
			return string.Format(FoodAdded, name, type);
		}

		public string AddTable(string type, int tableNumber, int capacity)
		{
			ITable table;
			if(type == nameof(InsideTable))
			{
				table = new InsideTable(tableNumber, capacity);
			}
			else
			{
				table = new OutsideTable(tableNumber, capacity);
			}

			this.tables.Add(table);
			return string.Format(TableAdded, tableNumber);
		}

		public string GetFreeTablesInfo()
		{
			StringBuilder sb =new StringBuilder();

			foreach(var table in this.tables.Where(t => !t.IsReserved))
			{
				sb.AppendLine(table.GetFreeTableInfo());
			}

			return sb.ToString().TrimEnd();
		}

		public string GetTotalIncome()
		{
			return string.Format(TotalIncome, this.totalIncome);
		}

		public string LeaveTable(int tableNumber)
		{
			ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
			decimal bill = table.GetBill();
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Table: {tableNumber}");
			sb.AppendLine($"Bill: {bill:f2}");
			table.Clear();
			this.totalIncome += bill;

			return sb.ToString().TrimEnd();
		}

		public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
		{
			ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
			if (table == null)
			{
				return string.Format(WrongTableNumber, tableNumber);
			}

			IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName);
			if(drink == null)
			{
				return string.Format(NonExistentDrink, drinkName, drinkBrand);
			}

			table.OrderDrink(drink);
			return string.Format(FoodOrderSuccessful, tableNumber, $"{drinkName} {drinkBrand}");
		}

		public string OrderFood(int tableNumber, string foodName)
		{
			ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
			if(table == null)
			{
				return string.Format(WrongTableNumber, tableNumber);
			}

			IBakedFood food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);
			if(food == null)
			{
				return string.Format(NonExistentFood, foodName);
			}

			table.OrderFood(food);
			return string.Format(FoodOrderSuccessful, tableNumber, foodName);
		}

		public string ReserveTable(int numberOfPeople)
		{
			ITable table = this.tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);
			if(table == null)
			{
				return string.Format(ReservationNotPossible, numberOfPeople);
			}

			table.Reserve(numberOfPeople);
			return string.Format(TableReserved, table.TableNumber, numberOfPeople);
		}
	}
}
