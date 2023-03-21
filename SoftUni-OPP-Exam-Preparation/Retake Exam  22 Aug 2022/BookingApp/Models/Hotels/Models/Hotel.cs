using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Linq;
using static BookingApp.Utilities.Messages.ExceptionMessages;

namespace BookingApp.Models.Hotels.Models
{
	public class Hotel : IHotel
	{
		public Hotel(string fullName, int category)
		{
			FullName = fullName;
			Category = category;
		}

		private string fullName;

		public string FullName
		{
			get { return fullName; }
			private set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException(HotelNameNullOrEmpty);
				}
				fullName = value;
			}
		}

		private int category;

		public int Category
		{
			get { return category; }
			private set
			{
				if (value < 1 && value > 5)
				{
					throw new ArgumentException(InvalidCategory);
				}
				category = value;
			}
		}

		private double turnover;

		public double Turnover
		{
			get { return turnover; }
			private set
			{
				turnover = this.bookings.All().Sum(b => Math.Round(b.ResidenceDuration * b.Room.PricePerNight, 2));
			}
		}

		private RoomRepository rooms = new RoomRepository();

		public IRepository<IRoom> Rooms
		{
			get { return rooms; }
		}

		private BookingRepository bookings = new BookingRepository();

		public IRepository<IBooking> Bookings
		{
			get { return bookings; }
		}
	}
}
