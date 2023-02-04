Dictionary<string, int> countKeys = new Dictionary<string, int>();

string[] inputKeys = Console.ReadLine()
    .Split()
    .ToArray();

foreach (string key in inputKeys)
{
    if(countKeys.ContainsKey(key))
    {
        countKeys[key]++;
    }
    else
    {
        countKeys.Add(key, 1);
    }
}

foreach (var key in countKeys)
{
    Console.WriteLine($"{key.Key} - {key.Value} times");
}