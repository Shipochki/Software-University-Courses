using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Repositories;
using System;
using static ChristmasPastryShop.Utilities.Messages.OutputMessages;
using System.Collections.Generic;
using System.Text;
using ChristmasPastryShop.Models.Delicacies.Models;
using System.Linq;
using ChristmasPastryShop.Models.Cocktails.Models;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;

namespace ChristmasPastryShop.Core
{
	public class Controller : IController
	{
		private BoothRepository booths = new BoothRepository();

		public string AddBooth(int capacity)
		{
			Booth newBooth = new Booth(this.booths.Models.Count + 1, capacity);
			this.booths.AddModel(newBooth);

			return string.Format(NewBoothAdded, newBooth.BoothId, capacity);
		}

		public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
		{
			if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
			{
				return string.Format(InvalidCocktailType, cocktailTypeName);
			}

			if (size != "Large" && size != "Middle" && size != "Small")
			{
				return string.Format(InvalidCocktailSize, size);
			}

			IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

			if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
			{
				return string.Format(CocktailAlreadyAdded, size, cocktailName);
			}

			if (cocktailTypeName == nameof(Hibernation))
			{
				Hibernation hibernation = new Hibernation(cocktailName, size);
				booth.CocktailMenu.AddModel(hibernation);
			}
			else if (cocktailTypeName == nameof(MulledWine))
			{
				MulledWine mulledWine = new MulledWine(cocktailName, size);
				booth.CocktailMenu.AddModel(mulledWine);
			}

			return string.Format(NewCocktailAdded, size, cocktailName, cocktailTypeName);
		}

		public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
		{
			if (delicacyTypeName != nameof(Stolen) && delicacyTypeName != nameof(Gingerbread))
			{
				return string.Format(InvalidDelicacyType, delicacyTypeName);
			}

			IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

			if (booth.DelicacyMenu.Models.Any(m => m.Name == delicacyName))
			{
				return string.Format(DelicacyAlreadyAdded, delicacyName);
			}

			if (delicacyTypeName == nameof(Stolen))
			{
				Stolen stolen = new Stolen(delicacyName);
				booth.DelicacyMenu.AddModel(stolen);
			}
			else if (delicacyTypeName == nameof(Gingerbread))
			{
				Gingerbread gingerbread = new Gingerbread(delicacyName);
				booth.DelicacyMenu.AddModel(gingerbread);
			}

			return string.Format(NewDelicacyAdded, delicacyTypeName, delicacyName);
		}

		public string BoothReport(int boothId)
		{
			IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
			return booth.ToString();
		}

		public string LeaveBooth(int boothId)
		{
			IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
			sb.AppendLine($"Booth {boothId} is now available!");

			booth.Charge();
			booth.ChangeStatus();

			return sb.ToString().TrimEnd();
		}

		public string ReserveBooth(int countOfPeople)
		{
			IBooth booth = this.booths
				.Models
				.Where(m => m.IsReserved == false && m.Capacity >= countOfPeople)
				.OrderBy(m => m.Capacity)
				.ThenByDescending(m => m.BoothId)
				.FirstOrDefault();

			if (booth == null)
			{
				return string.Format(NoAvailableBooth, countOfPeople);
			}
			else
			{
				booth.ChangeStatus();
				return string.Format(BoothReservedSuccessfully, booth.BoothId, countOfPeople);
			}
		}

		public string TryOrder(int boothId, string order)
		{
			List<string> elements = order.Split('/').ToList();
			string itemTypeName = elements[0];
			string itemName = elements[1];
			int countPieces = int.Parse(elements[2]);
			string size = string.Empty;
			if (itemTypeName == nameof(Hibernation) ||
				itemTypeName == nameof(MulledWine) &&
				elements.Count == 4)
			{
				size = elements[3];
			}

			IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

			if (itemTypeName != nameof(Hibernation) &&
				itemTypeName != nameof(MulledWine) &&
				itemTypeName != nameof(Gingerbread) &&
				itemTypeName != nameof(Stolen))
			{
				return string.Format(NotRecognizedType, itemTypeName);
			}


			if (size != string.Empty)
			{

				ICocktail cocktail = booth.CocktailMenu
					.Models
					.FirstOrDefault(c => c.Name == itemName && c.Size == size);

				if (cocktail == null)
				{
					return string.Format(NotRecognizedItemName, size, itemName);
				}

				booth.UpdateCurrentBill(cocktail.Price * countPieces);
				return string.Format(SuccessfullyOrdered, booth.BoothId, countPieces, itemName);
			}
			else
			{

				IDelicacy delicacy = booth.DelicacyMenu
					.Models
					.FirstOrDefault(c => c.Name == itemName);

				if (delicacy == null)
				{
					return string.Format(NotRecognizedItemName, itemTypeName, itemName);
				}

				booth.UpdateCurrentBill(delicacy.Price * countPieces);
				return string.Format(SuccessfullyOrdered, booth.BoothId, countPieces, itemName);
			}
		}
	}
}
