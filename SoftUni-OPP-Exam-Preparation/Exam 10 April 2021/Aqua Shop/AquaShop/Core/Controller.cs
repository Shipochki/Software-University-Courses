using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using static AquaShop.Utilities.Messages.ExceptionMessages;
using static AquaShop.Utilities.Messages.OutputMessages;
using System.Text;
using AquaShop.Models.Decorations;
using System.Linq;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish;

namespace AquaShop.Core
{
	public class Controller : IController
	{
		private IRepository<IDecoration> decorations;
		private ICollection<IAquarium> aquariums;

		public Controller()
		{
			this.decorations = new DecorationRepository();
			this.aquariums = new List<IAquarium>();
		}

		public string AddAquarium(string aquariumType, string aquariumName)
		{
			if(aquariumType != nameof(FreshwaterAquarium) 
				&& aquariumType != nameof(SaltwaterAquarium))
			{
				throw new InvalidOperationException(InvalidAquariumType);
			}

			IAquarium aquarium;
			if(aquariumType == nameof(FreshwaterAquarium))
			{
				aquarium = new FreshwaterAquarium(aquariumName);
			}
			else
			{
				aquarium = new SaltwaterAquarium(aquariumName);
			}

			this.aquariums.Add(aquarium);
			return string.Format(SuccessfullyAdded, aquariumType);
		}

		public string AddDecoration(string decorationType)
		{
			if(decorationType != nameof(Ornament) &&
				decorationType != nameof(Plant))
			{
				throw new InvalidOperationException(InvalidDecorationType);
			}

			IDecoration decoration;
			if(decorationType == nameof(Ornament))
			{
				decoration = new Ornament();
			}
			else
			{
				decoration = new Plant();
			}

			this.decorations.Add(decoration);

			return string.Format(SuccessfullyAdded, decorationType);
		}

		public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
		{
			if(fishType != nameof(FreshwaterFish) 
				&& fishType != nameof(SaltwaterFish))
			{
				throw new InvalidOperationException(InvalidFishType);
			}

			IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

			IFish fish;
			if(fishType == nameof(FreshwaterFish))
			{
				if(aquarium.GetType().Name == nameof(FreshwaterAquarium))
				{
					fish = new FreshwaterFish(fishName, fishSpecies, price);
				}
				else
				{
					return string.Format(UnsuitableWater);
				}
			}
			else
			{
				if (aquarium.GetType().Name == nameof(SaltwaterAquarium))
				{
					fish = new SaltwaterFish(fishName, fishSpecies, price);
				}
				else
				{
					return string.Format(UnsuitableWater);
				}
			}

			aquarium.AddFish(fish);
			return string.Format(EntityAddedToAquarium, fishType, aquariumName);
		}

		public string CalculateValue(string aquariumName)
		{
			IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
			decimal totalPrice = aquarium.Fish.Sum(f => f.Price);
			totalPrice += aquarium.Decorations.Sum(d => d.Price);

			return string.Format(AquariumValue, aquariumName, Math.Round(totalPrice, 2));
		}

		public string FeedFish(string aquariumName)
		{
			IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
			aquarium.Feed();
			return string.Format(FishFed, aquarium.Fish.Count);
		}

		public string InsertDecoration(string aquariumName, string decorationType)
		{
			IDecoration decoration = this.decorations.FindByType(decorationType);
			if(decoration == null)
			{
				throw new InvalidOperationException(string.Format(InexistentDecoration, decorationType));
			}

			IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
			aquarium.AddDecoration(decoration);
			this.decorations.Remove(decoration);

			return string.Format(EntityAddedToAquarium, decorationType, aquariumName);
		}

		public string Report()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var aquarium in this.aquariums)
			{
				sb.AppendLine(aquarium.GetInfo());
				sb.AppendLine();
			}

			return sb.ToString().TrimEnd();
		}
	}
}
