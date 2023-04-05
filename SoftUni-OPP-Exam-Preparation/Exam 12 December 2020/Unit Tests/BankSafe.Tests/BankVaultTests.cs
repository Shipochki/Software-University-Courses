using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            BankVault bank = new BankVault();
            Item item = new Item("Item", "1");

            string result = bank.AddItem("A1", item);
            string expected = $"Item:{item.ItemId} saved successfully!";

			IReadOnlyDictionary<string, Item> items = bank.VaultCells;
            Assert.That(items["A1"].Equals(item));

            Assert.That(result.Equals(expected));
        }


        [Test] 
        public void Test2()
        {
			BankVault bank = new BankVault();
			Item item = new Item("Item", "1");
			bank.AddItem("A1", item);

			Assert.Throws<ArgumentException>(() =>
			{
				bank.AddItem("fgf", item);
			});

			Assert.Throws<ArgumentException>(() =>
			{
				bank.AddItem("A1", item);
			});

			Assert.Throws<InvalidOperationException>(() =>
			{
				bank.AddItem("A2", item);
			});
		}


        [Test]
        public void Test3()
        {
			BankVault bank = new BankVault();
			Item item = new Item("Item", "1");
			bank.AddItem("A1", item);

            string result = bank.RemoveItem("A1", item);
            string expected = $"Remove item:{item.ItemId} successfully!";

            Assert.That(result.Equals(expected));
		}


        [Test]
        public void Test4()
        {
			BankVault bank = new BankVault();
			Item item = new Item("Item", "1");
			bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() =>
            {
                bank.RemoveItem("sd1", item);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                bank.RemoveItem("B1", item);
            });
		}
	}
}