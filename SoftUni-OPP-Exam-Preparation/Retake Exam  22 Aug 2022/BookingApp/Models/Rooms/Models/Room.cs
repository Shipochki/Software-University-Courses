using BookingApp.Models.Rooms.Contracts;
using System;
using static BookingApp.Utilities.Messages.ExceptionMessages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms.Models
{
	public class Room : IRoom
	{
		public Room(int bedCapacity)
		{
			BedCapacity = bedCapacity;
		}

		private int bedCapacity;

		public int BedCapacity
		{
			get { return bedCapacity; }
			private set { bedCapacity = value; }
		}

		private double pricePerNight = 0;

		public double PricePerNight
		{
			get { return pricePerNight; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentException(PricePerNightNegative);
				}

				pricePerNight = value;
			}
		}


		public void SetPrice(double price)
		{
			PricePerNight = price;
		}
	}
}
