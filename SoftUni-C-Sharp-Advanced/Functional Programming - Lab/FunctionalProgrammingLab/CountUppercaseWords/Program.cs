using System;
using System.Linq;

namespace CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isUpper = c => c[0] == c.ToUpper()[0];

            var words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(c => isUpper(c));

            words.ToList().ForEach(word => Console.WriteLine(word));
        }
    }
}
