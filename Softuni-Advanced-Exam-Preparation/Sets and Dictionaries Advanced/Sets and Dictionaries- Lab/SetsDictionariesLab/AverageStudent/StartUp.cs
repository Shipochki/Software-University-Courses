Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

int numOfInputLines = int.Parse(Console.ReadLine());

for (int i = 0; i < numOfInputLines; i++)
{
    string[] splitedData = Console.ReadLine()
        .Split()
        .ToArray();

    string name = splitedData[0];
    decimal grade = decimal.Parse(splitedData[1]);

    if (!studentsGrades.ContainsKey(name))
    {
        studentsGrades[name] = new List<decimal>();
    }

    studentsGrades[name].Add(grade);
}


foreach (var student in studentsGrades)
{
    Console.Write($"{student.Key} -> ");
    foreach (var grades in student.Value)
    {
        Console.Write($"{grades:f2} ");
    }
    Console.Write($"(avg: {student.Value.Average():f2})");
    Console.WriteLine();
}