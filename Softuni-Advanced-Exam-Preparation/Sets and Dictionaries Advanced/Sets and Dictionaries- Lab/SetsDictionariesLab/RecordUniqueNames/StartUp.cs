HashSet<string> names = new HashSet<string>();
int lines = int.Parse(Console.ReadLine());

for(int i = 0;i < lines; i++)
{
    names.Add(Console.ReadLine());
}

foreach(string name in names)
{
    Console.WriteLine(name);
}