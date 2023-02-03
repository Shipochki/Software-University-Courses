int[] rowsAndColsParm = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int rows = rowsAndColsParm[0];
int cols = rowsAndColsParm[1];

string[,] matrix = new string[rows, cols];

for (int row = 0; row < matrix.GetLength(0); row++)
{
    string[] splitedInputData = Console.ReadLine()
        .Split()
        .ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = splitedInputData[col];
    }
}

while (true)
{
    string inputData = Console.ReadLine();

    if(inputData == "END")
    {
        break;
    }

    string[] splitedData = inputData.Split().ToArray();

    if(splitedData.Length != 5)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    string comand = splitedData[0];
    int row1 = int.Parse(splitedData[1]);
    int col1 = int.Parse(splitedData[2]);
    int row2 = int.Parse(splitedData[3]);
    int col2 = int.Parse(splitedData[4]);

    if(comand != "swap" || row1 < 0 || col1 < 0 || row2 < 0 || col2 < 0)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    if (row1 > matrix.GetLength(0) || col1 > matrix.GetLength(1) ||
        row2 > matrix.GetLength(0) || col2 > matrix.GetLength(1))
    {
        Console.WriteLine("Invalid input!");
        continue;
    }

    string firstCell = matrix[row1, col1];
    string secondCell = matrix[row2, col2];

    matrix[row2, col2] = firstCell;
    matrix[row1, col1] = secondCell;

    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col] + " ");
        }
        Console.WriteLine();
    }
}