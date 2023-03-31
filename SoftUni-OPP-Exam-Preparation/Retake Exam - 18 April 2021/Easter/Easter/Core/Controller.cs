using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using System;
using static Easter.Utilities.Messages.ExceptionMessages;
using static Easter.Utilities.Messages.OutputMessages;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Workshops.Contracts;
using Easter.Models.Workshops;
using System.Linq;

namespace Easter.Core
{
	public class Controller : IController
	{
		IRepository<IBunny> bunnys;
		IRepository<IEgg> eggs;
		IWorkshop workshop;

		public Controller()
		{
			this.bunnys = new BunnyRepository();
			this.eggs = new EggRepository();
			this.workshop = new Workshop();
		}

		public string AddBunny(string bunnyType, string bunnyName)
		{
			if (bunnyType != nameof(HappyBunny)
				&& bunnyType != nameof(SleepyBunny))
			{
				throw new InvalidOperationException(InvalidBunnyType);
			}

			IBunny bunny;
			if (bunnyType == nameof(HappyBunny))
			{
				bunny = new HappyBunny(bunnyName);
			}
			else
			{
				bunny = new SleepyBunny(bunnyName);
			}

			this.bunnys.Add(bunny);

			return string.Format(BunnyAdded, bunnyType, bunnyName);
		}

		public string AddDyeToBunny(string bunnyName, int power)
		{
			IBunny bunny = this.bunnys.FindByName(bunnyName);
			if (bunny == null)
			{
				throw new InvalidOperationException(InexistentBunny);
			}

			IDye dye = new Dye(power);
			bunny.AddDye(dye);

			return string.Format(DyeAdded, power, bunnyName);
		}

		public string AddEgg(string eggName, int energyRequired)
		{
			IEgg egg = new Egg(eggName, energyRequired);

			this.eggs.Add(egg);

			return string.Format(EggAdded, eggName);
		}

		public string ColorEgg(string eggName)
		{
			ICollection<IBunny> bunnies = this.bunnys
				.Models
				.OrderByDescending(b => b.Energy)
				.Where(b => b.Energy >= 50)
				.ToList();

			if (bunnies.Count == 0)
			{
				throw new InvalidOperationException(BunniesNotReady);
			}

			IEgg egg = this.eggs.FindByName(eggName);

			foreach (var bunny in bunnies)
			{
				this.workshop.Color(egg, bunny);

				if (bunny.Energy == 0)
				{
					this.bunnys.Remove(bunny);
				}

				if (egg.IsDone())
				{
					break;
				}
			}

			if (egg.IsDone())
			{
				return string.Format(EggIsDone, eggName);
			}
			else
			{
				return string.Format(EggIsNotDone, eggName);
			}
		}

		public string Report()
		{
			int coloredEggsCount = this.eggs
				.Models
				.Where(e => e.IsDone())
				.Count();

			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{coloredEggsCount} eggs are done!");
			sb.AppendLine("Bunnies info:");

			foreach (var bunny in this.bunnys.Models)
			{
				int bunnyDyesCount = bunny.Dyes.Where(d => !d.IsFinished()).Count();
				sb.AppendLine($"Name: {bunny.Name}");
				sb.AppendLine($"Energy: {bunny.Energy}");
				sb.AppendLine($"Dyes: {bunnyDyesCount} not finished");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
