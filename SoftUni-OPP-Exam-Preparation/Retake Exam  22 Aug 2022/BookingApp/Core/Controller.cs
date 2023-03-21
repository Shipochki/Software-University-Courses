using BookingApp.Core.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Hotels.Models;
using BookingApp.Models.Rooms.Models;
using BookingApp.Repositories;
using System;
using System.Linq;
using System.Text;
using static BookingApp.Utilities.Messages.OutputMessages;
using static BookingApp.Utilities.Messages.ExceptionMessages;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Bookings.Models;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core
{
	public class Controller : IController
	{
		private readonly IRepository<IHotel> hotels = new HotelRepository();

		public string AddHotel(string hotelName, int category)
		{
			if (this.hotels.Select(hotelName) != null)
			{
				return string.Format(HotelAlreadyRegistered, hotelName);
			}

			IHotel hotel = new Hotel(hotelName, category);

			this.hotels.AddNew(hotel);

			return string.Format(HotelSuccessfullyRegistered, category, hotelName);
		}

		public string BookAvailableRoom(int adults, int children, int duration, int category)
		{
			if (this.hotels.All().FirstOrDefault(x => x.Category == category) == default)
			{
				return string.Format(OutputMessages.CategoryInvalid, category);
			}
			var orderedHotels =
				this.hotels.All().Where(x => x.Category == category).ThenBy(x => x.FullName);


			foreach (var hotel in orderedHotels)
			{
				var selectedRoom = hotel.Rooms.All()
					.Where(x => x.PricePerNight > 0)
					.Where(y => y.BedCapacity >= adults + children)
					.OrderBy(z => z.BedCapacity).FirstOrDefault();

				if (selectedRoom != null)
				{
					int bookingNumber = this.hotels.All().Sum(x => x.Bookings.All().Count) + 1;
					IBooking booking = new Booking(selectedRoom, duration, adults, children, bookingNumber);
					hotel.Bookings.AddNew(booking);
					return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
				}
			}

			return string.Format(OutputMessages.RoomNotAppropriate);
		}

		public string HotelReport(string hotelName)
		{
			IHotel hotel = this.hotels.Select(hotelName);
			if (hotel == null)
			{
				return string.Format(HotelNameInvalid, hotelName);
			}

			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"Hotel name: {hotelName}");
			sb.AppendLine($"--{hotel.Category} star hotel");
			sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
			sb.AppendLine($"--Bookings:");
			sb.AppendLine();

			if (hotel.Bookings.All().Count == 0)
			{
				sb.AppendLine("none");
			}
			else
			{
				foreach (var booking in hotel.Bookings.All())
				{
					sb.AppendLine(booking.BookingSummary());
					sb.AppendLine();
				}
			}

			return sb.ToString().TrimEnd();
		}

		public string SetRoomPrices(string hotelName, string roomTypeName, double price)
		{
			IHotel hotel = this.hotels.Select(hotelName);
			if (hotel == null)
			{
				return string.Format(HotelNameInvalid, hotelName);
			}

			if (roomTypeName != nameof(Apartment) && roomTypeName != nameof(DoubleBed)
				&& roomTypeName != nameof(Studio))
			{
				throw new ArgumentException(RoomTypeIncorrect);
			}

			IRoom room = hotel.Rooms.Select(roomTypeName);

			if (room == null)
			{
				return string.Format(RoomTypeNotCreated);
			}

			if (room.PricePerNight > 0)
			{
				throw new InvalidOperationException(CannotResetInitialPrice);
			}

			room.SetPrice(price);

			return string.Format(PriceSetSuccessfully, roomTypeName, hotelName);
		}

		public string UploadRoomTypes(string hotelName, string roomTypeName)
		{
			IHotel hotel = this.hotels.Select(hotelName);
			if (hotel == null)
			{
				return string.Format(HotelNameInvalid, hotelName);
			}

			if (hotel.Rooms.Select(roomTypeName) != null)
			{
				return string.Format(RoomTypeAlreadyCreated);
			}

			if (roomTypeName != nameof(Apartment) && roomTypeName != nameof(DoubleBed)
				&& roomTypeName != nameof(Studio))
			{
				throw new ArgumentException(RoomTypeIncorrect);
			}

			IRoom room;

			if (roomTypeName == nameof(Apartment))
			{
				room = new Apartment();
			}
			else if (roomTypeName == nameof(DoubleBed))
			{
				room = new DoubleBed();
			}
			else
			{
				room = new Studio();
			}

			hotel.Rooms.AddNew(room);

			return string.Format(RoomTypeAdded, roomTypeName, hotelName);
		}
	}
}
