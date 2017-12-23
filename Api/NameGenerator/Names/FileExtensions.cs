using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNameGenerator
{
    public static class FileExtensions
    {
        public static string GetContent(this FileInfo fileInfo)
        {
            using (var streamReader = new StreamReader(new FileStream(fileInfo.FullName, FileMode.OpenOrCreate)))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static IEnumerable<string> GetLines(this FileInfo fileInfo)
        {
            using (var streamReader = new StreamReader(new FileStream(fileInfo.FullName, FileMode.OpenOrCreate)))
            {
                while (!streamReader.EndOfStream)
                {
                    yield return streamReader.ReadLine();
                }
            }
        }

        public static void SaveToFile(this string content, string filePath)
        {
            using (var streamWriter = new StreamWriter(new FileStream(filePath, FileMode.OpenOrCreate)))
            {
                streamWriter.Write(content);
            }
        }

        public static void SaveToFile(this IEnumerable<string> lines, string filePath)
        {
            using (var streamWriter = new StreamWriter(new FileStream(filePath, FileMode.OpenOrCreate)))
            {
                foreach (var line in lines)
                {
                    streamWriter.WriteLine(line);
                }
            }
        }
    }
}
