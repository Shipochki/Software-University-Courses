Dictionary<string, int> keyValuePairs= new Dictionary<string, int>();

int lines = int.Parse(Console.ReadLine());  

for(int i = 0;i < lines; i++)
{
    string inputData = Console.ReadLine();

    if(!keyValuePairs.ContainsKey(inputData))
    {
        keyValuePairs.Add(inputData, 0);
    }

    keyValuePairs[inputData]++;
}

foreach (var item in keyValuePairs)
{
    if(item.Value % 2 == 0)
    {
        Console.WriteLine(item.Key);
    }
}