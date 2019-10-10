using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AsciiCombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Minimum two arguments needed!");
                return;
            }

            List<string> fileContents = new List<string>();
            int firstNumChars = 0;
            int firstNumLines = 0;

            foreach (string arg in args)
            {
                // get content of file
                string content = ReadFile(arg);
                string[] splitContent = content.Split("\n");

                if (!CheckIfContentValid(content))
                {
                    Console.WriteLine($"File {arg} has different number characters per line!");
                    return;
                }

                if (fileContents.Count < 1)
                {
                    firstNumChars = splitContent[0].Length;
                    firstNumLines = splitContent.Length;
                    fileContents.Add(content);
                    continue;
                }

                if (splitContent.Length != firstNumLines)
                {
                    Console.WriteLine($"File {arg} has different number of lines!");
                    return;
                }

                // prove if new file meets requirements
                foreach (string s in splitContent)
                {
                    if (s.Length != firstNumChars)
                    {
                        Console.WriteLine("Files have different number characters per line!");
                        return;
                    }
                }

                // add file content to list
                fileContents.Add(content);
            }

            Logic logic = new Logic();
            Console.WriteLine(logic.Merge(fileContents));
        }

        static bool CheckIfContentValid(string content)
        {
            string[] splitContent = content.Split("\n");
            int charsPerLine = splitContent[0].Length;

            for (int i = 1; i < splitContent.Length; i++)
            {
                if (splitContent[i].Length != charsPerLine)
                {
                    return false;
                }
            }
            return true;
        }

        static string ReadFile(string fileName)
        {
            string content = string.Empty;
            try
            {
                content = File.ReadAllText("./TestData/" + fileName);
                content = content.Replace("\r", string.Empty);
            }
            catch (IOException e)
            {
                Console.WriteLine($"File {fileName} not found!");
                throw;
            }
            return content;
        }
    }
}
