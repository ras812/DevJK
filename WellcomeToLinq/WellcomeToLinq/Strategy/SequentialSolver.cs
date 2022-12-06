using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using WellcomeToLinq.WordsHandler;

namespace WellcomeToLinq.Strategy
{
    public class SequentialSolver : IStrategy
    {

        Dictionary<int, int> IStrategy.FrequentWordsDictionaryLengthCount(string filePath)
        {
            var sortedList = new SortedList<int, int>();
            string[] words = Handler.GetWordsFromFiles(new Handler(filePath));

            foreach (var word in words)
            {
                if (!sortedList.ContainsKey(word.Length))
                {
                    sortedList.Add(word.Length, 1);
                }
                else
                {
                    sortedList[word.Length]++;
                }
            }

            var res = new Dictionary<int, int>(sortedList.Reverse());

            return res;
        }


        //нахождение самого длинного слова по множеству слов
        string IStrategy.GetLongestWord(string filePath)
        {
            int maxWordLength = 0;
            string res = "";
            string[] words = Handler.GetWordsFromFiles(new Handler(filePath));

            foreach (var word in words)
            {
                if (word.Length >= maxWordLength)
                {
                    res = word;
                    maxWordLength = word.Length;
                }
            }

            return res;
        }

        // нахождение 10 самых часто встречающихся слов
        string[] IStrategy.TenMostFrequentWords(string filePath)
        {
            var res = new string[10];
            var superMaxValue = int.MaxValue;
            var dictionary = Handler.GetFrequentWordsDictionary(new Handler(filePath));

            for (int i = 0; i < 10; i++)
            {
                int max = 0;
                string result = "";

                foreach (var item in dictionary)
                {
                    if (item.Value >= max && item.Value < superMaxValue)
                    {
                        max = item.Value;
                        result = item.Key;
                    }
                }

                superMaxValue = max;
                res[i] = result;
            }

            return res;
        }
    }
}
