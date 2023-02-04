HashSet<string> usernames = new HashSet<string>();

int lines = int.Parse(Console.ReadLine());

for(int i = 0;i < lines; i++)
{
    string username = Console.ReadLine();
    usernames.Add(username);
}

foreach(string username in usernames)
{
    Console.WriteLine(username);
}