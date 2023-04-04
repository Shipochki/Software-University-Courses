using System;
using System.Collections.Generic;
using System.Linq;
using static WarCroft.Constants.ExceptionMessages;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
	public abstract class Bag : IBag
	{
		public Bag(int capacity)
		{
			Capacity = capacity;
			this.items = new List<Item>();
		}
		
		public int Capacity { get; set; } = 100;

		public int Load => this.items.Sum(i => i.Weight);

		private List<Item> items;

		public IReadOnlyCollection<Item> Items => this.items;

		public void AddItem(Item item)
		{
			if(this.Capacity == this.items.Count)
			{
				throw new InvalidOperationException(ExceedMaximumBagCapacity);
			}

			this.items.Add(item);
		}

		public Item GetItem(string name)
		{
			if(this.Items.Count== 0)
			{
				throw new InvalidOperationException(EmptyBag);
			}

			Item item = this.items.FirstOrDefault(i => i.GetType().Name == name);
			if(item == null)
			{
				throw new ArgumentException(string.Format(ItemNotFoundInBag, name));
			}

			this.items.Remove(item);
			return item;
		}
	}
}
