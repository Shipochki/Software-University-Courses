using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Test1()
        {
            Shop shop = new Shop(5);
            Assert.That(shop.Capacity.Equals(5));

            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-1);
            });
        }

        [Test]
        public void Test2()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone = new Smartphone("Lenovo", 5000);
            Smartphone smartphone1 = new Smartphone("Xiaomi", 4800);
			Smartphone smartphone2 = new Smartphone("Samsung", 3500);
			shop.Add(smartphone);

            Assert.That(shop.Count.Equals(1));

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone);
            });

            shop.Add(smartphone1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone2);
            });
        }

        [Test]
        public void Test3()
        {
			Shop shop = new Shop(1);
			Smartphone smartphone = new Smartphone("Lenovo", 5000);
			shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Xiaomi");
            });

            shop.Remove("Lenovo");

            Assert.That(shop.Count.Equals(0));
		}

        [Test]
        public void Test4()
        {
			Shop shop = new Shop(1);
			Smartphone smartphone = new Smartphone("Lenovo", 5000);
			shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Xiaomi", 4800);
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Lenovo", 5100);
            });

            shop.TestPhone("Lenovo", 4900);

            Assert.That(smartphone.CurrentBateryCharge.Equals(100));
		}

        [Test]
        public void Test5()
        {
			Shop shop = new Shop(1);
			Smartphone smartphone = new Smartphone("Lenovo", 5000);
			shop.Add(smartphone);
			shop.TestPhone("Lenovo", 4900);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Xiaomi");
            });

            shop.ChargePhone("Lenovo");

            Assert.That(smartphone.CurrentBateryCharge.Equals(smartphone.MaximumBatteryCharge));
		}
    }
}