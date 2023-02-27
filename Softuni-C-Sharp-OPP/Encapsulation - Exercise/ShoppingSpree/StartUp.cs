using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> firstLineData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> secondLineData = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<Person> customers = new List<Person>();
            List<Product> products = new List<Product>();

            foreach (var customer in firstLineData)
            {
                try
                {
                    List<string> splitedData = customer.Split("=").ToList();
                    string name = splitedData[0];
                    decimal money = decimal.Parse(splitedData[1]);
                    Person person = new Person(name, money);
                    customers.Add(person);
                }
                catch (Exception o)
                {
                    Console.WriteLine(o.Message);
                    return;
                }
            }

            foreach (var item in secondLineData)
            {
                try
                {
                    List<string> splitedData = item.Split("=").ToList();
                    string name = splitedData[0];
                    decimal cost = decimal.Parse(splitedData[1]);
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (Exception o)
                {
                    Console.WriteLine(o.Message);
                    return;
                }
            }

            string inputData = Console.ReadLine();

            while (inputData != "END")
            {
                string[] splitedData = inputData.Split().ToArray();
                string personName = splitedData[0];
                string productName = splitedData[1];

                foreach (var customer in customers)
                {
                    if (customer.Name == personName)
                    {
                        foreach (var product in products)
                        {
                            if (product.Name == productName)
                            {
                                customer.BuyProduct(product);
                                break;
                            }
                        }
                        break;
                    }
                }

                inputData = Console.ReadLine();
            }

            foreach (var customer in customers)
            {
                if (customer.Bag.Count == 0)
                    Console.WriteLine($"{customer.Name} - Nothing bought ");
                else
                {
                    Console.WriteLine($"{customer.Name} - {string.Join(", ", customer.Bag.Select(x => x.Name))}");
                }
            }
        }
    }
}
