using SortingAlgorithms.Algorithms.Searching;
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
    public class SearchingOption : IAlgorithmOption
    {
        private readonly object searchLock = new object();

        /// <inheritdoc />
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
                        await Task.WhenAll(CallSearchMethod(new BinarySearch(new MergeSort(), new ArrayValidator()), inputValidator.AskArraySize(), inputValidator.AskSearchedElement()));
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

        /// <summary>
        /// Method creates and runs searching tasks for different types of arrays (int[], string[], Guid[]).
        /// </summary>
        /// <param name="searchingAlgorithm">Algorithm that is used for searching.</param>
        /// <param name="arraySize">Size of the used arrays.</param>
        /// <param name="searchedElement">Element that needs to be searched in arrays.</param>
        /// <returns>List of Tasks</returns>
        private List<Task> CallSearchMethod(ISearchingAlgorithm searchingAlgorithm, int arraySize, string searchedElement)
        {
            var tasks = new List<Task>();
            Console.Clear();

            tasks.Add(Task.Run(() =>
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                var task = Task.Run(() =>
                {
                    int.TryParse(searchedElement, out int intElement);

                    searchingAlgorithm.Search(ArrayGenerator.GenerateIntArray(arraySize), intElement);
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

                var task = Task.Run(() => searchingAlgorithm.Search(ArrayGenerator.GenerateStringArray(arraySize), searchedElement));

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
                    Guid.TryParse(searchedElement, out Guid guidElement);

                    searchingAlgorithm.Search(ArrayGenerator.GenerateGuidArray(arraySize), guidElement);
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
