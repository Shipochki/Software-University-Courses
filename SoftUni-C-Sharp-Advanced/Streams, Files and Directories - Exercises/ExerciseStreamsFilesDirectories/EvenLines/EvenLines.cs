namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static StringBuilder ProcessLines(string inputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var output = new StringBuilder();

            using (reader)
            {
                var line = reader.ReadLine();
                var specialSymb = '@';
                while (line != null)
                {
                    var textoutput = string.Empty;
                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        if (char.IsPunctuation(line[i]))
                            textoutput += specialSymb;
                        else
                            textoutput += line[i];
                    }
                    output.AppendLine(textoutput);
                    line = reader.ReadLine();
                }
            }
            return output;
        }
    }
}
