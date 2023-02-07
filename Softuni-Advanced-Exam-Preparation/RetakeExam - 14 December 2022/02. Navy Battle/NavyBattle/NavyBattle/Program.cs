int size = int.Parse(Console.ReadLine());

char[,] battlefield = new char[size, size];

int[] postionBattleShip = new int[2];
int countCruiser = 0;

for (int row = 0; row < battlefield.GetLength(0); row++)
{
    string battleLine = Console.ReadLine();
    for (int col = 0; col < battlefield.GetLength(1); col++)
    {
        battlefield[row, col] = battleLine[col];
        if (battleLine[col] == 'S')
        {
            postionBattleShip[0] = row;
            postionBattleShip[1] = col;
            battlefield[row, col] = '-';
        }
        else if (battleLine[col] == 'C')
        {
            countCruiser++;
        }
    }
}

int countMines = 0;

while (true)
{
    if (countMines == 3 || countCruiser == 0)
    {
        break;
    }

    string comand = Console.ReadLine();
    int row = postionBattleShip[0];
    int col = postionBattleShip[1];

    if (comand == "up")
    {
        if (row > 0)
        {

            if (battlefield[row - 1, col] == '*')
            {
                countMines++;
                battlefield[row - 1, col] = '-';
            }
            else if (battlefield[row - 1, col] == 'C')
            {
                countCruiser--;
                battlefield[row - 1, col] = '-';
            }

            postionBattleShip[0] -= 1;
        }
    }
    else if (comand == "down")
    {
        if (row < battlefield.GetLength(0))
        {

            if (battlefield[row + 1, col] == '*')
            {
                countMines++;
                battlefield[row + 1, col] = '-';
            }
            else if (battlefield[row + 1, col] == 'C')
            {
                countCruiser--;
                battlefield[row + 1, col] = '-';
            }

            postionBattleShip[0] += 1;
        }
    }
    else if (comand == "left")
    {
        if (col > 0)
        {

            if (battlefield[row, col - 1] == '*')
            {
                countMines++;
                battlefield[row, col - 1] = '-';
            }
            else if (battlefield[row, col - 1] == 'C')
            {
                countCruiser--;
                battlefield[row, col - 1] = '-';
            }

            postionBattleShip[1] -= 1;
        }
    }
    else if(comand == "right")
    {
        if (col < battlefield.GetLength(1))
        {

            if (battlefield[row, col + 1] == '*')
            {
                countMines++;
                battlefield[row, col + 1] = '-';
            }
            else if (battlefield[row, col + 1] == 'C')
            {
                countCruiser--;
                battlefield[row, col + 1] = '-';
            }

            postionBattleShip[1] += 1;
        }
    }
}

battlefield[postionBattleShip[0], postionBattleShip[1]] = 'S';

if(countCruiser == 0 && countMines < 3)
{
    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
}
else
{
    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{postionBattleShip[0]}, {postionBattleShip[1]}]!");
}

for (int row = 0; row < battlefield.GetLength(0); row++)
{
    for (int col = 0; col < battlefield.GetLength(1); col++)
    {
        Console.Write($"{battlefield[row, col]}");
    }
    Console.WriteLine();
}
