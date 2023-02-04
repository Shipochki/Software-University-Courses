HashSet<string> cars = new HashSet<string>();

while (true)
{
    string[] splitedData = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();

    if (splitedData[0] == "END")
    {
        break;
    }

    string comand = splitedData[0];
    string carPlate = splitedData[1];

    if (comand == "IN")
    {
        if (!cars.Contains(carPlate))
        {
            cars.Add(carPlate);
        }
    }
    else if (comand == "OUT")
    {
        if (cars.Contains(carPlate))
        {
            cars.Remove(carPlate);
        }
    }
}

if(cars.Count == 0)
{
    Console.WriteLine("Parking Lot is Empty");
    return;
}

foreach (var car in cars)
{
    Console.WriteLine(car);
}