using System;
using System.Collections.Generic;

namespace CitiesContinentCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfLine = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numOfLine; i++)
            {
                var inputInfo = Console.ReadLine().Split();
                string continent = inputInfo[0];
                string country = inputInfo[1];
                string city = inputInfo[2];

                if (!continents.ContainsKey(continent))
                    continents.Add(continent, new Dictionary<string, List<string>>());

                if (!continents[continent].ContainsKey(country))
                    continents[continent].Add(country, new List<string>());

                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}: ");
                foreach (var country in continent.Value)
                {
                    Console.Write($"  {country.Key} -> {string.Join(", ", country.Value)}");
                    Console.WriteLine();
                }
            }
        }
    }
}
