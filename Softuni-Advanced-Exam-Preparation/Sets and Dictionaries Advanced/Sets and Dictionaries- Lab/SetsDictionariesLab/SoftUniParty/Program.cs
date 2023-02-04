HashSet<string> guests = new HashSet<string>();
HashSet<string> vipGuests = new HashSet<string>();

while (true)
{
    string inputData = Console.ReadLine();

    if (inputData == "PARTY")
    {
        break;
    }

    if (char.IsDigit(inputData[0]))
    {
        vipGuests.Add(inputData);
    }
    else
    {
        guests.Add(inputData);
    }

}

while (true)
{
    string inputData = Console.ReadLine();

    if (inputData == "END")
    {
        break;
    }

    if (char.IsDigit(inputData[0]))
    {
        vipGuests.Remove(inputData);
    }
    else
    {
        guests.Remove(inputData);
    }
}

Console.WriteLine(guests.Count + vipGuests.Count);
foreach (var vipGuest in vipGuests)
{
    Console.WriteLine(vipGuest);
}
foreach (var guest in guests)
{
    Console.WriteLine(guest);
}