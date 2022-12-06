using System;
using System.Collections.Generic;
using System.Text;
using WellcomeToLinq.WordsHandler;

namespace WellcomeToLinq.Strategy
{
    public class Context
    {
        private readonly string _filePath;
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy strategy, string filePath)
        {
            ContextStrategy = strategy;
            _filePath = filePath;
        }

        public string ExecuteGetLongestWord()
        {
            return ContextStrategy.GetLongestWord(_filePath);
        }

        public string[] ExecuteTenMostFrequentWords()
        {
            return ContextStrategy.TenMostFrequentWords(_filePath);
        }

        public Dictionary<int, int> ExecuteFrequentWordsDictionaryLengthCount()
        {
            return ContextStrategy.FrequentWordsDictionaryLengthCount(_filePath);
        }
    }
}
