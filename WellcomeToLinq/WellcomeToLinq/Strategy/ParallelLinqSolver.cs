﻿using System;
using System.Collections.Generic;
using System.Linq;
using WellcomeToLinq.WordsHandler;


namespace WellcomeToLinq.Strategy
{
    public class ParallelLinqSolver : IStrategy
    {
        public ParallelLinqSolver()
        {
        }

        //нахождение статистики по длине слов(получить словарь, в котором ключ – длина
        //слова, а значение – количество слов такой длины; словарь упорядочен по
        //убыванию длины слов)
        Dictionary<int, int> IStrategy.FrequentWordsDictionaryLengthCount(string filePath)
        {
            string[] words = Handler.GetWordsFromFilesByParallelLinq(new Handler(filePath));
            var res = words.AsParallel()
                                                            .Select(p => p.Length)
                                                            .GroupBy(p => p)
                                                            .ToDictionary(p => p.Key,
                                                                        p => p.Count())
                                                            .OrderBy(r => -r.Key);
            return new Dictionary<int, int>(res);
        }

        //нахождение самого длинного слова по множеству слов
        string IStrategy.GetLongestWord(string filePath)
        {
            string[] words = Handler.GetWordsFromFilesByParallelLinq(new Handler(filePath));
            var res = words.AsParallel()
                                    .OrderByDescending(word => word.Length)
                                    .First();
            return res;
        }

        // нахождение 10 самых часто встречающихся слов
        string[] IStrategy.TenMostFrequentWords(string filePath)
        {
            var dictionary = Handler.GetFrequentWordsDictionaryByParallelLinq(new Handler(filePath));

            var res = dictionary.AsParallel()
                                        .OrderByDescending(item => item.Value)
                                        .Take(10)
                                        .Select(item => item.Key)
                                        .ToArray();
            return res;
        }
    }
}

