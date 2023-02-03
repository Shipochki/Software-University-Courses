int rows = int.Parse(Console.ReadLine());

int[][] jaggetMatrix = new int[rows][];

for (int row = 0;row < jaggetMatrix.GetLength(0); row++)
{
    int[] columsInput = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

    jaggetMatrix[row] = new int[columsInput.Length];

    for (int col = 0; col < columsInput.Length; col++)
    {
        jaggetMatrix[row][col] = columsInput[col];
    }
}

while(true)
{
    string inputData = Console.ReadLine();

    if(inputData == "END")
    {
        break;
    }

    string[] splitedData = inputData.Split().ToArray();

    string comand = splitedData[0];
    int row = int.Parse(splitedData[1]);
    int col = int.Parse(splitedData[2]);
    int value = int.Parse(splitedData[3]);

    if (row < 0 || col < 0 || jaggetMatrix.Length <= row || jaggetMatrix[row].Length <= col)
    {
        Console.WriteLine("Invalid coordinates");
        continue;
    }

    if(comand == "Add")
    {
        jaggetMatrix[row][col] += value;
    }
    else if(comand == "Subtract")
    {
        jaggetMatrix[row][col] -= value;
    }
}

for (int row = 0; row < jaggetMatrix.GetLength(0); row++)
{
    Console.WriteLine(string.Join(" ", jaggetMatrix[row]));
}