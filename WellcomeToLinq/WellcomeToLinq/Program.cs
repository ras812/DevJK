using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using WellcomeToLinq.Strategy;
using WellcomeToLinq.WordsHandler;

namespace WellcomeToLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filePath = @"/Users/Aleks/Projects/_PersonalRepo/WellcomeToLinq/Chesterton";    // for MAC
            string filePath = @"D:\ProgC\PersonalRepo\WellcomeToLinq\Chesterton";
            

            IStrategy strategy = new SequentialSolver();
            var context = new Context(strategy, filePath);

            var view = new View(strategy, context);
            view.RunView();
            view.RunSwTimer();

            strategy = new LinqSolver();
            context = new Context(strategy, filePath);

            view = new View(strategy, context);
            view.RunView();
            view.RunSwTimer();

            strategy = new ParallelLinqSolver();
            context = new Context(strategy, filePath);

            view = new View(strategy, context);
            view.RunView();
            view.RunSwTimer();

            Environment.Exit(0);

            #region WriteToFile

            // write result to file
            //string fileName = @"/Users/Aleks/Projects/DevGame/WellcomeToLinq/out.txt";
            //File.WriteAllLines(fileName, result);
            //Console.WriteLine("Write to file [out.txt] complete.");

            #endregion
        }
    }
}

