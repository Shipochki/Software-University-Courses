int rows = int.Parse(Console.ReadLine());

int[][] jaggedMatrix = new int[rows][];

for (int row = 0; row < jaggedMatrix.GetLength(0); row++)
{
    int[] splitedData = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    jaggedMatrix[row] = splitedData;
}

for (int row = 0; row < jaggedMatrix.GetLength(0) - 1; row++)
{
    if (jaggedMatrix[row].Length == jaggedMatrix[row + 1].Length)
    {
        for (int col = 0; col < jaggedMatrix[row].Length; col++)
        {
            jaggedMatrix[row][col] *= 2;
            jaggedMatrix[row + 1][col] *= 2;
        }
    }
    else
    {
        for (int col = 0; col < jaggedMatrix[row].Length; col++)
        {
            jaggedMatrix[row][col] /= 2;

        }
        for (int col = 0; col < jaggedMatrix[row + 1].Length; col++)
        {
            jaggedMatrix[row + 1][col] /= 2;
        }
    }
}

while (true)
{
    string inputData = Console.ReadLine();

    if(inputData == "End")
    {
        break;
    }

    string[] splitedData = inputData.Split().ToArray();

    if(splitedData.Length != 4)
    {
        continue;
    }

    string comand = splitedData[0];
    int row = int.Parse(splitedData[1]);
    int col = int.Parse(splitedData[2]);
    int value = int.Parse(splitedData[3]);

    if(row < 0 || col < 0 || row >= jaggedMatrix.GetLength(0) || jaggedMatrix[row].Length <= col)
    {
        continue;
    }

    if(comand == "Add")
    {
        jaggedMatrix[row][col] += value;
    }
    else if(comand == "Subtract")
    {
        jaggedMatrix[row][col] -= value;
    }
}

for (int row = 0; row < jaggedMatrix.GetLength(0); row++)
{
    for (int col = 0; col < jaggedMatrix[row].Length; col++)
    {
        Console.Write($"{jaggedMatrix[row][col]} ");
    }
    Console.WriteLine();
}