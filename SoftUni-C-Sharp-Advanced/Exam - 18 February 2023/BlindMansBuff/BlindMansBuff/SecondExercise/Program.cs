using System.ComponentModel;

int[] size = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = size[0];
int cols = size[1];

char[,] matrix = new char[rows, cols];

int countPlayers = 0;
int countTuched = 0;
int countMoves = 0;
int[] B = new int[2];

for (int row = 0; row < rows; row++)
{
    char[] input = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();
    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = input[col];
        if (input[col] == 'B')
        {
            B[0] = row;
            B[1] = col;
        }
        else if (input[col] == 'P')
        {
            countPlayers++;
        }
    }
}

string comand = Console.ReadLine();

while (comand != "Finish" && countTuched != countPlayers)
{
    matrix[B[0], B[1]] = '-';
    if(comand == "up")
    {
        if (B[0] - 1 >= 0 && matrix[B[0] - 1, B[1]] != 'O')
        {
            B[0]--;
            countMoves++;
        }
    }
    else if(comand == "down")
    {
        if (B[0] + 1 < rows && matrix[B[0] + 1, B[1]] != 'O')
        {
            B[0]++;
            countMoves++;
        }
    }
    else if(comand == "right")
    {
        if (B[1] + 1 < cols && matrix[B[0], B[1] + 1] != 'O')
        {
            B[1]++;
            countMoves++;
        }
    }
    else if(comand == "left")
    {
        if (B[1] - 1 >= 0 && matrix[B[0], B[1] - 1] != 'O')
        {
            B[1]--;
            countMoves++;
        }
    }

    if (matrix[B[0], B[1]] == 'P')
    {
        countTuched++;
    }

    comand = Console.ReadLine();
}

matrix[B[0], B[1]] = 'B';

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {countTuched} Moves made: {countMoves}");