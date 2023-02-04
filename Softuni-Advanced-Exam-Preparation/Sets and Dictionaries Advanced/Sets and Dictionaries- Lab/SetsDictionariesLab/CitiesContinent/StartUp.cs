Dictionary<string, Dictionary<string, List<string>>> continentData =
    new Dictionary<string, Dictionary<string, List<string>>>();

int inputLines = int.Parse(Console.ReadLine());

for (int line = 0; line < inputLines; line++)
{
    string[] splitedData = Console.ReadLine().Split();

    string continent = splitedData[0];
    string country = splitedData[1];
    string city = splitedData[2];

    if(!continentData.ContainsKey(continent))
    {
        continentData.Add(continent, new Dictionary<string, List<string>>());
    }

    if (!continentData[continent].ContainsKey(country))
    {
        continentData[continent].Add(country, new List<string>());
    }

    continentData[continent][country].Add(city);
}

foreach (var continent in continentData)
{
    Console.WriteLine($"{continent.Key}:");
    foreach (var country in continent.Value)
    {
        Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
    }
}