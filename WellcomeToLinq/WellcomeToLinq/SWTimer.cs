using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using WellcomeToLinq.WordsHandler;

namespace WellcomeToLinq
{
    public class SWTimer
    {
        public static void RunSwTimer(string filePath, int count = 10)
        {
            var swNoLinq = new Stopwatch();
            var swLinq = new Stopwatch();
            var swPLinq = new Stopwatch();

            var handler = new Handler(filePath);

            Console.WriteLine($"START GetFrequentWordsDictionary Stopwatch Timer Test\n");

            for (int i = 0; i < count; i++)
            {
                swNoLinq.Reset();
                swNoLinq.Start();
                Handler.GetFrequentWordsDictionary(handler);
                swNoLinq.Stop();
                var nolinqElapsed = swNoLinq.ElapsedMilliseconds;

                swLinq.Reset();
                swLinq.Start();
                Handler.GetFrequentWordsDictionaryByLinq(handler);
                swLinq.Stop();
                var linqElapsed = swLinq.ElapsedMilliseconds;

                swPLinq.Reset();
                swPLinq.Start();
                Handler.GetFrequentWordsDictionaryByParallelLinq(handler);
                swPLinq.Stop();
                var plinqElapsed = swPLinq.ElapsedMilliseconds;

                Console.WriteLine($"#{i + 1}\tNoLinq:\t{nolinqElapsed} mls,\tLinq:\t{linqElapsed} mls,\tPLinq:\t{plinqElapsed} mls");
            }

            Console.WriteLine($"\nSTOP GetFrequentWordsDictionary Stopwatch Timer Test");
        }
    }
}