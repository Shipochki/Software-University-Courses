int[] parms = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

HashSet<int> firstSet = new HashSet<int>();
HashSet<int> secondSet = new HashSet<int>();

for(int i = 0;i < parms[0]; i++)
{
    int num = int.Parse(Console.ReadLine());
    firstSet.Add(num);
}

for(int i = 0;i < parms[1]; i++)
{
    int num = int.Parse(Console.ReadLine());
    secondSet.Add(num);
}

foreach (var firstNum in firstSet)
{
    if(secondSet.Contains(firstNum))
    {
        Console.Write(firstNum + " ");
    }
}