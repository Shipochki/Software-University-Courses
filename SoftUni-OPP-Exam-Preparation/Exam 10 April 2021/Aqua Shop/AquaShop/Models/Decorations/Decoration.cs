using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
	public class Decoration : IDecoration
	{
		public Decoration(int comfort, decimal price)
		{
			this.comfort = comfort;
			this.price = price;
		}

		private int comfort;

		public int Comfort => this.comfort;

		private decimal price;

		public decimal Price => this.price;

	}
}
