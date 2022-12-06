using System;
using System.Collections.Generic;
using System.Text;
using WellcomeToLinq.WordsHandler;

namespace WellcomeToLinq.Strategy
{
    public interface IStrategy
    {
        public string GetLongestWord(string filePath);

        public string[] TenMostFrequentWords(string filePath);

        public Dictionary<int, int> FrequentWordsDictionaryLengthCount(string filePath);
    }
}
