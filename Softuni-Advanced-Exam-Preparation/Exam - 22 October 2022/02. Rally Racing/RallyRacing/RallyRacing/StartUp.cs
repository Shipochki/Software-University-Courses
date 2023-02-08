int size = int.Parse(Console.ReadLine());
int[] car = new int[2];
car[0] = 0; 
car[1] = 0;

string racingCar = Console.ReadLine();

char[,] matrix = new char[size, size];

Dictionary<int, int> tunelCordinates = new Dictionary<int, int>();
Dictionary<int, int> finish = new Dictionary<int, int>();

for (int row = 0; row < matrix.GetLength(0); row++)
{
	char[] line = Console.ReadLine()
		.Split(" ", StringSplitOptions.RemoveEmptyEntries)
		.Select(char.Parse)
		.ToArray();
	for (int col = 0; col < matrix.GetLength(1); col++)
	{
		matrix[row, col] = line[col];
		if (line[col] == 'T')
		{
			tunelCordinates.Add(row, col);
		}
		else if (line[col] == 'F')
		{
			finish.Add(row, col);
		}
	}
}

int distance = 0;
bool readyToFinish = false;
bool isFinish = false;

while (true)
{
	string comand = Console.ReadLine();
	if (comand == "End")
	{
		break;
	}

	int rowCar = car[0];
	int colCar = car[1];

	if (comand == "up")
	{
		if (rowCar > 0 && matrix.GetLength(0) > rowCar)
		{
			car[0]--;
		}
	}
	else if (comand == "down")
	{

		if (rowCar >= 0 && matrix.GetLength(0) > rowCar)
		{
			car[0]++;
		}
	}
	else if (comand == "right")
	{
		if (colCar >= 0 && matrix.GetLength(1) > colCar)
		{
			car[1]++;
		}
	}
	else if (comand == "left")
	{
		if (colCar > 0 && matrix.GetLength(1) > colCar)
		{
			car[1]--;
		}
	}

	if (matrix[car[0], car[1]] == 'T')
	{
		matrix[car[0], car[1]] = '.';
		tunelCordinates.Remove(car[0]);
		car[0] = tunelCordinates.First().Key;
		car[1] = tunelCordinates.First().Value;
		tunelCordinates.Remove(car[0]);
		matrix[car[0], car[1]] = '.';
		distance += 30;
		readyToFinish= true;
    }
	else if(matrix[car[0], car[1]] == 'F')
	{
		matrix[car[0], car[1]] = 'C';
		distance += 10;
		isFinish = true;
		break;
	}
	else 
	{
		distance += 10;
	}
}

matrix[car[0], car[1]] = 'C';

if (isFinish)
{
	Console.WriteLine($"Racing car {racingCar} finished the stage!");
}
else
{
	Console.WriteLine($"Racing car {racingCar} DNF.");
}

Console.WriteLine($"Distance covered {distance} km.");

for (int row = 0; row < matrix.GetLength(0); row++)
{
	for (int col = 0; col < matrix.GetLength(1); col++)
	{
		Console.Write(matrix[row,col]);
	}
	Console.WriteLine();
}