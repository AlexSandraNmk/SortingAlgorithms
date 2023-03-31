using SortingAlgorithms.Algorithms.Sorting;
using SortingAlgorithms.Helpers;
using SortingAlgorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.UserInteraction
{
    public class SortingOption : IAlgorithmOption
    {
        private readonly object sortLock = new object();

        public async Task ExecuteAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose sorting type:");
                Console.WriteLine("1 - Bubble sort");
                Console.WriteLine("2 - Merge sort");
                Console.WriteLine("b - Back");
                Console.WriteLine("x - Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await Task.WhenAll(CallSortMethod(new BubbleSort(), new InputValidator().AskArraySize()));
                        break;
                    case "2":
                        await Task.WhenAll(CallSortMethod(new MergeSort(), new InputValidator().AskArraySize()));
                        break;
                    case "b":
                        return;
                    case "x":
                        Environment.Exit(0);
                        break;
                }

                Console.Write("\nPress Enter");
                Console.ReadLine();
            }
        }

        private List<Task> CallSortMethod(ISortingAlgorithm sortingAlgorithm, int arraySize)
        {
            ArrayGenerator arrayGenerator = new ArrayGenerator(arraySize);
            var tasks = new List<Task>();

            Console.Clear();

            tasks.Add(Task.Run(() =>
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                var task = Task.Run(() => sortingAlgorithm.Sort(arrayGenerator.GenerateIntArray()));
                
                while(!task.IsCompleted)
                {
                    lock (sortLock)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"{sortingAlgorithm.GetType().Name}    int: {watch.Elapsed}");
                    }
                }

                watch.Stop();
            }));

            tasks.Add(Task.Run(() =>
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                var task = Task.Run(() => sortingAlgorithm.Sort(arrayGenerator.GenerateStringArray()));
                
                while (!task.IsCompleted)
                {
                    lock (sortLock)
                    {
                        Console.SetCursorPosition(0, 1);
                        Console.WriteLine($"{sortingAlgorithm.GetType().Name} string: {watch.Elapsed}");
                    }
                }

                watch.Stop();
            }));

            tasks.Add(Task.Run(() =>
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                
                var task = Task.Run(() => sortingAlgorithm.Sort(arrayGenerator.GenerateGuidArray()));
                
                while (!task.IsCompleted)
                {
                    lock (sortLock)
                    {
                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine($"{sortingAlgorithm.GetType().Name}   guid: {watch.Elapsed}");
                    }
                }

                watch.Stop();
            }));

            return tasks;
        }
    }
}
