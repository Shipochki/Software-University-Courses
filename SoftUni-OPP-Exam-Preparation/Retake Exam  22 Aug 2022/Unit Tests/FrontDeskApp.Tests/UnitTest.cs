using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				Hotel hotel = new Hotel(null, 2);
			});

			Assert.Throws<ArgumentException>(() =>
			{
				Hotel hotel = new Hotel("Hotel1", 0);
			});

			Assert.Throws<ArgumentException>(() =>
			{
				Hotel hotel = new Hotel("Hotel1", 6);
			});
		}

		[Test]
		public void Test2()
		{
			Hotel hotel = new Hotel("Hotel1", 2);
			string resultName = "Hotel1";
			int resultCategory = 2;

			Assert.That(hotel.FullName.Equals(resultName));
			Assert.That(hotel.Category.Equals(resultCategory));
		}

		[Test]
		public void Test3()
		{
			Hotel hotel = new Hotel("Hotel1", 2);
			Room room = new Room(4, 25);
			hotel.AddRoom(room);
			Room testRoom = hotel.Rooms.First();

			Assert.That(hotel.Rooms.Count.Equals(1));
			Assert.That(testRoom.BedCapacity.Equals(room.BedCapacity));
		}

		[Test]
		public void Test4()
		{
			Hotel hotel = new Hotel("Hotel1", 2);
			Room room = new Room(4, 25);
			hotel.AddRoom(room);

			Assert.Throws<ArgumentException>(() =>
			{
				hotel.BookRoom(0, 1, 3, 50);
			});

			Assert.Throws<ArgumentException>(() =>
			{
				hotel.BookRoom(1, -1, 3, 50);
			});

			Assert.Throws<ArgumentException>(() =>
			{
				hotel.BookRoom(1, 0, 0, 50);
			});
		}

		[Test]
		public void Test5()
		{
			Hotel hotel = new Hotel("Hotel1", 2);
			Room room = new Room(4, 25);
			hotel.AddRoom(room);
			hotel.BookRoom(2, 0, 3, 50);

			Assert.That(hotel.Bookings.Count.Equals(0));

			hotel.BookRoom(2, 0, 3, 75);
			Assert.That(hotel.Bookings.Count.Equals(1));

			Assert.That(hotel.Bookings.First().Room.PricePerNight.Equals(25));

			Assert.That(hotel.Turnover.Equals(75));
		}
	}
}