namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var firstListOfText = new List<string>();
            var firstReader = new StreamReader(firstInputFilePath);
            using (firstReader)
            {
                var line = firstReader.ReadLine();
                while (line != null)
                {
                    firstListOfText.Add(line);
                    line = firstReader.ReadLine();
                }
            }

            var secondListOfText = new List<string>();
            var secondReader = new StreamReader(secondInputFilePath);
            using (secondReader)
            {
                var line = secondReader.ReadLine();
                while (line != null)
                {
                    secondListOfText.Add(line);
                    line = secondReader.ReadLine();
                }
            }

            var biggestList = new List<string>();
            var smallestList = new List<string>();

            if (firstListOfText.Count > secondListOfText.Count)
            {
                biggestList = firstListOfText;
                smallestList = secondListOfText;
            }
            else
            {
                biggestList = secondListOfText;
                smallestList = firstListOfText;
            }

            var writer = new StreamWriter(outputFilePath);
            using (writer)
            {
                for (int i = 0; i < smallestList.Count; i++)
                {
                    writer.WriteLine(firstListOfText[i]);
                    writer.WriteLine(secondListOfText[i]);
                }

                for (int i = smallestList.Count; i < biggestList.Count; i++)
                {
                    writer.WriteLine(biggestList[i]);
                }
            }
        }
    }
}
