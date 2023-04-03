using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using static AquaShop.Utilities.Messages.ExceptionMessages;
using System.Text;
using System.Linq;

namespace AquaShop.Models.Aquariums
{
	public class Aquarium : IAquarium
	{
		public Aquarium(string name, int capacity)
		{
			Name = name;
			this.capacity = capacity;
			this.decorations = new List<IDecoration>();
			this.fish = new List<IFish>();
		}

		private string name;

		public string Name
		{
			get { return name; }
			private set 
			{ 
				if(string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(InvalidAquariumName);
				}
				name = value; 
			}
		}

		private int capacity;

		public int Capacity => capacity;

		public int Comfort => this.decorations.Sum(d => d.Comfort);


		private List<IDecoration> decorations;

		public ICollection<IDecoration> Decorations => this.decorations;
		

		private List<IFish> fish;

		public ICollection<IFish> Fish => this.fish;


		public void AddDecoration(IDecoration decoration)
		{
			this.decorations.Add(decoration);
		}

		public void AddFish(IFish fish)
		{
			if(this.capacity == this.fish.Count)
			{
				throw new InvalidOperationException(NotEnoughCapacity);
			}

			this.fish.Add(fish);
		}

		public void Feed()
		{
			foreach (var fish in this.fish)
			{
				fish.Eat();
			}
		}

		public string GetInfo()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
			if(this.fish.Count > 0)
			{
				sb.AppendLine($"Fish: {string.Join(", ", this.fish.Select(f => f.Name))}");
			}
			else
			{
				sb.AppendLine($"Fish: none");
			}
			sb.AppendLine($"Decorations: {this.decorations.Count}");
			sb.AppendLine($"Comfort: {this.Comfort}");

			return sb.ToString().TrimEnd();
		}

		public bool RemoveFish(IFish fish)
		{
			return this.fish.Remove(fish);
		}
	}
}
