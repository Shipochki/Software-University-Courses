using System.Collections.Generic;

int StamatCaffeine = 0;

int[] inputCaffeine = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int[] inputDrinks = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Stack<int> caffeine = new Stack<int>(inputCaffeine);

Queue<int> drinks = new Queue<int>(inputDrinks);

while (true)
{
    if (caffeine.Count == 0 || drinks.Count == 0)
    {
        break;
    }

    if (caffeine.Peek() * drinks.Peek() + StamatCaffeine <= 300)
    {
        StamatCaffeine += caffeine.Pop() * drinks.Dequeue();
    }
    else
    {
        caffeine.Pop();
        drinks.Enqueue(drinks.Dequeue());
        if (StamatCaffeine - 30 < 0)
        {
            StamatCaffeine = 0;
        }
        else
        {
            StamatCaffeine -= 30;
        }
    }
}

if (drinks.Count > 0)
{
    Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
}
else
{
    Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
}

Console.WriteLine($"Stamat is going to sleep with {StamatCaffeine} mg caffeine.");