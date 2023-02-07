List<int> inputDataForFoodPortions = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

List<int> inputDataForStamina = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

Stack<int> foodPortions = new Stack<int>(inputDataForFoodPortions);

Queue<int> stamina = new Queue<int>(inputDataForStamina);

Dictionary<string, int> peaks = new Dictionary<string, int>()
{
    {"Vihren", 80 },
    {"Kutelo", 90 },
    {"Banski Suhodol", 100 },
    {"Polezhan", 60 },
    {"Kamenitza", 70 }
};

Queue<string> conqueredPeaks = new Queue<string>();

while (true)
{
    if(foodPortions.Count == 0 || stamina.Count == 0 || peaks.Count == 0)
    {
        break;
    }

    if(foodPortions.Peek() + stamina.Peek() >= peaks.First().Value)
    {
        conqueredPeaks.Enqueue(peaks.First().Key);
        foodPortions.Pop();
        stamina.Dequeue();
        peaks.Remove(peaks.First().Key);
    }
    else
    {
        foodPortions.Pop();
        stamina.Dequeue();
    }
}

if(conqueredPeaks.Count == 5)
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
}
else
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}

if(conqueredPeaks.Count > 0)
{
    Console.WriteLine("Conquered peaks:");
    foreach (var peak in conqueredPeaks)
    {
        Console.WriteLine(peak);
    }
}