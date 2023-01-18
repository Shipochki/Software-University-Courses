using System;
using System.Collections.Generic;

namespace ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] inputInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (inputInfo[0] == "Revision")
                    break;

                string shopName = inputInfo[0];
                string productName = inputInfo[1];
                double priceForProd = double.Parse(inputInfo[2]);

                if (!shops.ContainsKey(shopName))
                    shops.Add(shopName, new Dictionary<string, double>());

                shops[shopName].Add(productName, priceForProd);
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
