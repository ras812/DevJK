using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WellcomeToLinq.Strategy;
using WellcomeToLinq.WordsHandler;

namespace WellcomeToLinq
{
    public class View
    {
        private Context _context;
        private IStrategy _strategy;
        public View(IStrategy strategy, Context context)
        {
            _context = context;
            _strategy = strategy;
        }

        public void RunView()
        {
            Console.WriteLine($"\nRun strategy: {_strategy.GetType().Name}.");

            Console.WriteLine($"\nRun method: ExecuteGetLongestWord().");
            var s = _context.ExecuteGetLongestWord();
            Console.WriteLine($"Result: {s}");

            Console.WriteLine($"\nRun method: ExecuteTenMostFrequentWords().");
            var ss = _context.ExecuteTenMostFrequentWords();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"#{i+1} is {ss[i]}");
            }

            Console.WriteLine($"\nRun method: ExecuteFrequentWordsDictionaryLengthCount().");
            var dictionary = _context.ExecuteFrequentWordsDictionaryLengthCount();
            foreach (var item in dictionary)
            {
                Console.WriteLine($"WordLength is {item.Key}, WordsCount is {item.Value}");
            }
        }

        public void RunSwTimer(int count = 10)
        {
            var firstTimer = new Stopwatch();
            var secondTimer = new Stopwatch();
            var thirdTimer = new Stopwatch();

            Console.WriteLine($"\nSTART Stopwatch Timer Test\n");

            for (int i = 0; i < count; i++)
            {
                firstTimer.Reset();
                firstTimer.Start();
                var s = _context.ExecuteGetLongestWord();
                firstTimer.Stop();
                var firstTimerElapsed = firstTimer.ElapsedMilliseconds;

                secondTimer.Reset();
                secondTimer.Start();
                var ss = _context.ExecuteTenMostFrequentWords();
                secondTimer.Stop();
                var secondTimerElapsed = secondTimer.ElapsedMilliseconds;

                thirdTimer.Reset();
                thirdTimer.Start();
                var dictionary = _context.ExecuteFrequentWordsDictionaryLengthCount();
                thirdTimer.Stop();
                var thirdTimerElapsed = thirdTimer.ElapsedMilliseconds;

                Console.WriteLine($"#{i + 1}\tLongestWord:\t{firstTimerElapsed} mls," +
                                  $"\tTenMostFrequentWords:\t{secondTimerElapsed} mls," +
                                  $"\tWordsDictionaryLengthCount:\t{thirdTimerElapsed} mls");
            }

            Console.WriteLine($"\nSTOP Stopwatch Timer Test");
        }

    }
}
