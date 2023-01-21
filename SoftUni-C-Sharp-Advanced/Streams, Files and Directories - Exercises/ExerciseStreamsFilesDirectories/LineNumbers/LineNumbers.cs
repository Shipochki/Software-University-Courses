namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            using (reader)
            {
                var line = reader.ReadLine();
                var writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    int index = 1;
                    while (line != null)
                    {
                        int countLetter = 0;
                        int countPunctuation = 0;
                        foreach (var item in line)
                        {
                            if (char.IsLetter(item))
                                countLetter++;
                            else if (char.IsPunctuation(item))
                                countPunctuation++;
                        }
                        writer.WriteLine($"Line {index}: {line} ({countLetter})({countPunctuation})");
                        index++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
