namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);
            var extensionsInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (!extensionsInfo.ContainsKey(extension))
                    extensionsInfo.Add(extension, new List<FileInfo>());

                extensionsInfo[extension].Add(fileInfo);
            }

            extensionsInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);
            var info = new StringBuilder();

            foreach (var entry in extensionsInfo)
            {
                string extension = entry.Key;
                info.AppendLine(extension);

                List<FileInfo> filesInfo = entry.Value;
                filesInfo.OrderByDescending(file => files.Length);
                foreach (var fileInfo in filesInfo)
                {
                    info.AppendLine($"--{fileInfo.Name} - {fileInfo.Length / 1024:f3}kb");
                }
            }

            return info.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string pathReport = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(pathReport, textContent);
        }
    }
}
