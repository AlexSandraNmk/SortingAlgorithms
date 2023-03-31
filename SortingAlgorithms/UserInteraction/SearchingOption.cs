using SortingAlgorithms.Algorithms.Searching;
using SortingAlgorithms.Helpers;
using SortingAlgorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.UserInteraction
{
    public class SearchingOption : IAlgorithmOption
    {
        private readonly object searchLock = new object();

        public async Task ExecuteAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose searching type:");
                Console.WriteLine("1 - Linear search");
                Console.WriteLine("2 - Binary search");
                Console.WriteLine("b - Back");
                Console.WriteLine("x - Exit");

                string choice = Console.ReadLine();
                InputValidator inputValidator = new InputValidator();

                switch (choice)
                {
                    case "1":
                        await Task.WhenAll(CallSearchMethod(new LinearSearch(), inputValidator.AskArraySize(), inputValidator.AskSearchedElement()));
                        break;
                    case "2":
                        await Task.WhenAll(CallSearchMethod(new BinarySearch(), inputValidator.AskArraySize(), inputValidator.AskSearchedElement()));
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

        private List<Task> CallSearchMethod(ISearchingAlgorithm searchingAlgorithm, int arraySize, string searchedElement)
        {
            ArrayGenerator arrayGenerator = new ArrayGenerator(arraySize);
            
            var tasks = new List<Task>();
            Console.Clear();

            tasks.Add(Task.Run(() =>
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                var task = Task.Run(() =>
                {
                    int[] intArray = arrayGenerator.GenerateIntArray();
                    int.TryParse(searchedElement, out int intElement);

                    searchingAlgorithm.Search(intArray, intElement);
                });

                while (!task.IsCompleted)
                {
                    lock (searchLock)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"{searchingAlgorithm.GetType().Name}    int: {watch.Elapsed}");
                    }
                }

                watch.Stop();
            }));
            
            tasks.Add(Task.Run(() =>
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                var task = Task.Run(() =>
                {
                    string[] stringArray = arrayGenerator.GenerateStringArray();
                    searchingAlgorithm.Search(stringArray, searchedElement);
                });

                while (!task.IsCompleted)
                {
                    lock (searchLock)
                    {
                        Console.SetCursorPosition(0, 1);
                        Console.WriteLine($"{searchingAlgorithm.GetType().Name} string: {watch.Elapsed}");
                    }
                }

                watch.Stop();
            }));
            
            tasks.Add(Task.Run(() =>
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                var task = Task.Run(() =>
                {
                    Guid[] guidArray = arrayGenerator.GenerateGuidArray();
                    Guid.TryParse(searchedElement, out Guid guidElement);

                    searchingAlgorithm.Search(guidArray, guidElement);
                });

                while (!task.IsCompleted)
                {
                    lock (searchLock)
                    {
                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine($"{searchingAlgorithm.GetType().Name}  guid: {watch.Elapsed}");
                    }
                }

                watch.Stop();
            }));

            return tasks;
        }
    }
}
