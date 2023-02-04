SortedDictionary<char, int> countChars = new SortedDictionary<char, int>();

string text = Console.ReadLine();

foreach (var currentChar in text)
{
    if(!countChars.ContainsKey(currentChar))
    {
        countChars.Add(currentChar, 0);
    }

    countChars[currentChar]++;
}

foreach(var currentChar in countChars)
{
    Console.WriteLine($"{currentChar.Key}: {currentChar.Value} time/s");
}