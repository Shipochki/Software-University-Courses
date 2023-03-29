using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
	public class Backpack : IBag
	{
		public Backpack()
		{
			this.items = new List<string>();
		}

		private ICollection<string> items;

		public ICollection<string> Items => this.items;
	}
}
