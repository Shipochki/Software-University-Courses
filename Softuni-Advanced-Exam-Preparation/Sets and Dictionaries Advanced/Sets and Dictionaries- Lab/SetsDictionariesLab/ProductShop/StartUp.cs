SortedDictionary<string, Dictionary<string, double>>
    shopsData = new SortedDictionary<string, Dictionary<string, double>>();

while (true)
{
    string inputData = Console.ReadLine();

    if (inputData == "Revision")
    {
        break;
    }

    string[] splitedData = inputData
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    string shopName = splitedData[0];
    string productName = splitedData[1];
    double priceForProduct = double.Parse(splitedData[2]);

    if (!shopsData.ContainsKey(shopName))
    {
        shopsData.Add(shopName, new Dictionary<string, double>());
    }

    shopsData[shopName].Add(productName, priceForProduct);
}

foreach (var shop in shopsData)
{
    Console.WriteLine($"{shop.Key}->");
    foreach (var product in shop.Value)
    {
        Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
    }
}