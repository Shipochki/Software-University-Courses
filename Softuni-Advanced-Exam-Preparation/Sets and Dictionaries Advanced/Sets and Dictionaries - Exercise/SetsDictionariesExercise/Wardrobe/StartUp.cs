Dictionary<string, Dictionary<string, int>> wardrobe =
    new Dictionary<string, Dictionary<string, int>>();

int lines = int.Parse(Console.ReadLine());

for (int i = 0; i < lines; i++)
{
    string[] splitedColor = Console.ReadLine()
        .Split(" -> ")
        .ToArray();

    string[] clothes = splitedColor[1]
        .Split(",")
        .ToArray();

    string color = splitedColor[0];
    if (!wardrobe.ContainsKey(color))
    {
        wardrobe.Add(color, new Dictionary<string, int>());
    }

    foreach (var cloth in clothes)
    {
        if (!wardrobe[color].ContainsKey(cloth))
        {
            wardrobe[color].Add(cloth, 0);
        }
        wardrobe[color][cloth]++;
    }
}

string[] order = Console.ReadLine()
    .Split()
    .ToArray();

string orderColor = order[0];
string orderCloth = order[1];

foreach (var colors in wardrobe)
{
    Console.WriteLine($"{colors.Key} clothes:");
    foreach (var clothes in colors.Value)
    {
        if (colors.Key == orderColor && clothes.Key == orderCloth)
        {
            Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
        }
        else
        {
            Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
        }
    }
}