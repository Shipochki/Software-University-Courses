int[] sorted = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .OrderByDescending(n => n)
    .ToArray();

Console.WriteLine(string.Join(" ", sorted.Take(3)));