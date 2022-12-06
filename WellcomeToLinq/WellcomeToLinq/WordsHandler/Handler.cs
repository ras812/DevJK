using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WellcomeToLinq.WordsHandler
{
    public class Handler
    {
        private readonly string _filePath;
        private readonly char[] _delimiterChars;

        private string FilePath
        {
            get { return _filePath; }
        }

        private char[] DelimiterChars
        {
            get { return _delimiterChars; }
        }

        public Handler(string filePath)
        {
            _delimiterChars = GetDelimiterChars();
            _filePath = filePath;
        }
        private static char[] GetDelimiterChars()
        {
            var delimiterChars = new List<char>();

            int charMin = char.MinValue;
            int charMax = char.MaxValue;

            for (int i = charMin; i <= charMax; i++)
            {
                int num = i;
                char c = (char)num;

                if (char.IsSeparator(c) ||
                    char.IsPunctuation(c) ||
                    char.IsWhiteSpace(c) ||
                    char.IsControl(c) ||
                    char.IsSymbol(c)
                   )
                {
                    delimiterChars.Add(c);
                }
            }

            return delimiterChars.ToArray();
        }

        public static string[] GetWordsFromFiles(Handler handler)
        {
            string[] files = Directory.GetFiles(handler.FilePath);
            var res = new List<string>();

            foreach (var file in files)
            {
                string[] lines = File.ReadAllLines(file);

                foreach (var line in lines)
                {
                    string[] subline = line.Split(handler.DelimiterChars,
                                                  StringSplitOptions.RemoveEmptyEntries);
                    res.AddRange(subline);
                }
            }

            return res.ToArray();
        }

        public static string[] GetWordsFromFilesByLinq(Handler handler)
        {
            string[] files = Directory.GetFiles(handler.FilePath, "*.txt");
            string[] words = files.SelectMany(file => File.ReadAllText(file).Split(handler.DelimiterChars, StringSplitOptions.RemoveEmptyEntries))
                                    .ToArray();
            return words;
        }

        public static string[] GetWordsFromFilesByParallelLinq(Handler handler)
        {
            string[] files = Directory.GetFiles(handler.FilePath, "*.txt");
            string[] words = files.AsParallel()
                                    .SelectMany(file => File.ReadAllText(file).Split(handler.DelimiterChars, StringSplitOptions.RemoveEmptyEntries))
                                    .ToArray();
            return words;
        }
        
        public static Dictionary<string, int> GetFrequentWordsDictionary(Handler handler)
        {
            string[] words = Handler.GetWordsFromFiles(handler);

            var dictionary = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 1);
                }
                else
                {
                    dictionary[word]++;
                }
            }

            return dictionary;
        }

        public static Dictionary<string, int> GetFrequentWordsDictionaryByLinq(Handler handler)
        {
            string[] words = Handler.GetWordsFromFilesByLinq(handler);
            var dictionary = words.GroupBy(x => x)
                                  .ToDictionary(w => w.Key,
                                             w => w.Count());
            return dictionary;
        }

        public static Dictionary<string, int> GetFrequentWordsDictionaryByParallelLinq(Handler handler)
        {
            string[] words = Handler.GetWordsFromFilesByParallelLinq(handler);
            var dictionary = words.AsParallel()
                                    .GroupBy(x => x)
                                    .ToDictionary(w => w.Key,
                                                w => w.Count());
            return dictionary;
        }
    }
}

