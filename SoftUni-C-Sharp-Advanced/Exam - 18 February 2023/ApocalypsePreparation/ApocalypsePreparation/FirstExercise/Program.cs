int[] inputTextiles = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] inputMedicaments = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Queue<int> textiles = new Queue<int>(inputTextiles);

Stack<int> medicaments = new Stack<int>(inputMedicaments);

Dictionary<string, int> healingItems = new Dictionary<string, int>()
{
    {"Patch", 30 },
    {"Bandage", 40 },
    {"MedKit", 100 },
};

SortedDictionary<string, int> healingItemsCount = new SortedDictionary<string, int>()
{
    {"Patch", 0 },
    {"Bandage", 0 },
    {"MedKit", 0 },
};

while (textiles.Count > 0 && medicaments.Count > 0)
{
    int sum = textiles.Peek() + medicaments.Peek();

    if (healingItems.ContainsValue(sum))
    {
        foreach (var item in healingItems)
        {
            if (sum == item.Value)
            {
                healingItemsCount[item.Key]++;
                textiles.Dequeue();
                medicaments.Pop();
                break;
            }
        }
    }
    else if (100 < sum)
    {
        healingItemsCount["MedKit"]++;
        textiles.Dequeue();
        medicaments.Pop();
        medicaments.Push(medicaments.Pop() + sum - 100);
    }
    else
    {
        textiles.Dequeue();
        int currentMed = medicaments.Pop();
        medicaments.Push(currentMed + 10);
    }
}

if (textiles.Count == 0 && medicaments.Count > 0)
{
    Console.WriteLine("Textiles are empty.");
}
else if (medicaments.Count == 0 && textiles.Count > 0)
{
    Console.WriteLine("Medicaments are empty.");
}
else if (textiles.Count == 0 && medicaments.Count == 0)
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}

foreach (var item in healingItemsCount.OrderByDescending(h => h.Value))
{
    if (item.Value > 0)
    {
        Console.WriteLine($"{item.Key} - {item.Value}");
    }
}

if(medicaments.Count > 0)
{
    Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
}

if (textiles.Count > 0)
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
}