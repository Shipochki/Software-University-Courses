﻿using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
	public class BookingRepository : IRepository<IBooking>
	{
		private List<IBooking> bookings = new List<IBooking>();

		public void AddNew(IBooking model)
		{
			this.bookings.Add(model);
		}

		public IReadOnlyCollection<IBooking> All()
		{
			return this.bookings.AsReadOnly();
		}

		public IBooking Select(string criteria)
		{
			return this.bookings.FirstOrDefault(r => r.BookingNumber.ToString() == criteria);
		}
	}
}
