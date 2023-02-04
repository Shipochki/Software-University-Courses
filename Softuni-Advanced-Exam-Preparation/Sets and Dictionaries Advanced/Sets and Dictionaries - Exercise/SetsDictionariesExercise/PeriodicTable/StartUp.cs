HashSet<string> chemicalElemnts = new HashSet<string>();

int lines = int.Parse(Console.ReadLine());

for(int i = 0;i < lines; i++)
{
    string[] inputElements = Console.ReadLine()
        .Split()
        .ToArray();

    foreach (var element in inputElements)
    {
        chemicalElemnts.Add(element);
    }
}

Console.WriteLine(string.Join(" ", chemicalElemnts.OrderBy(e => e)));