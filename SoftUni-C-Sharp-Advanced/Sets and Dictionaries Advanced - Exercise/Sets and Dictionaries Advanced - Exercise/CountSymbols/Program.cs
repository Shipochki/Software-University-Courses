using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            var symbols = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (!symbols.ContainsKey(c))
                    symbols.Add(c, 0);

                symbols[c]++;
            }

            foreach (var symbol in symbols.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
