using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numOfLines; i++)
            {
                var inputInfo = Console.ReadLine().Split();
                if (!students.ContainsKey(inputInfo[0]))
                {
                    students[inputInfo[0]] = new List<decimal>();
                }
                students[inputInfo[0]].Add(decimal.Parse(inputInfo[1]));
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var item in student.Value)
                {
                    Console.Write($"{item:f2} ");
                }
                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
