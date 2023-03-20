using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using static ChristmasPastryShop.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Repositories;

namespace ChristmasPastryShop.Models.Booths
{
	public class Booth : IBooth
	{
		public Booth(int boothId, int capacity)
		{
			BoothId = boothId;
			Capacity = capacity;
			this.cocktailMenu = new CocktailRepository();
			this.delicacyMenu = new DelicacyRepository();
		}

		private int boothId;

		public int BoothId
		{
			get { return boothId; }
			private set { boothId = value; }
		}

		private int capacity;

		public int Capacity
		{
			get { return capacity; }
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException(CapacityLessThanOne);
				}

				capacity = value;
			}
		}

		private DelicacyRepository delicacyMenu;

		public IRepository<IDelicacy> DelicacyMenu => this.delicacyMenu;


		private CocktailRepository cocktailMenu;

		public IRepository<ICocktail> CocktailMenu => this.cocktailMenu;


		private double currentBill = 0;

		public double CurrentBill
		{
			get { return currentBill; }
			private set { currentBill = value; }
		}

		private double turnover = 0;

		public double Turnover
		{
			get { return turnover; }
			private set { turnover = value; }
		}

		private bool isReserved = false;

		public bool IsReserved
		{
			get { return isReserved; }
			private set { isReserved = value; }
		}


		public void ChangeStatus()
		{
			if (this.isReserved == true)
			{
				this.isReserved = false;
			}
			else
			{
				this.isReserved = true;
			}
		}

		public void Charge()
		{
			this.turnover += this.currentBill;
			this.currentBill = 0;
		}

		public void UpdateCurrentBill(double amount)
		{
			this.currentBill += amount;
		}

		public override string ToString()
		{
			StringBuilder output = new StringBuilder();
			output.AppendLine($"Booth: {this.boothId}");
			output.AppendLine($"Capacity: {this.capacity}");
			output.AppendLine($"Turnover: {this.turnover:f2} lv");
			output.AppendLine("-Cocktail menu:");
			foreach (var cocktail in this.cocktailMenu.Models)
			{
				output.AppendLine($"--{cocktail}");
			}
			output.AppendLine("-Delicacy menu:");
			foreach (var cocktail in this.delicacyMenu.Models)
			{
				output.AppendLine($"--{cocktail}");
			}

			return output.ToString().TrimEnd();
		}
	}
}
