namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var words = GetWords(wordsFilePath);

            var wordsCounter = new Dictionary<string, int>();
            foreach (var word in words)
                wordsCounter.Add(word, 0);

            var textReader = new StreamReader(textFilePath);
            using (textReader)
            {
                var line = textReader.ReadLine();
                string pattern = @"(\b[A-z]+['][A-z]+\b)|(\b[A-z]+\b)";

                while (line != null)
                {
                    var matches = Regex.Matches(line, pattern);

                    foreach (var item in matches)
                    {
                        string word = item.ToString().ToLower();
                        if (wordsCounter.ContainsKey(word))
                            wordsCounter[word]++;
                    }

                    line = textReader.ReadLine();
                }
            }

            var sortedWords = wordsCounter.OrderByDescending(x => x.Value);

            var writer = new StreamWriter(outputFilePath);
            using (writer)
            {
                foreach (var word in sortedWords)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }

        public static List<string> GetWords(string wordsFilePath)
        {
            List<string> words = new List<string>();
            var wordsReader = new StreamReader(wordsFilePath);
            using (wordsReader)
            {
                var input = wordsReader.ReadLine();

                while (input != null)
                {
                    var listedWords = input.Split();
                    foreach (var word in listedWords)
                        words.Add(word);

                    input = wordsReader.ReadLine();
                }
            }

            return words;
        }
    }
}
