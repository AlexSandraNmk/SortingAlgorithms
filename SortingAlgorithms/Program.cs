using SortingAlgorithms.Algorithms;
using SortingAlgorithms.Helpers;
using SortingAlgorithms.Interfaces;

var watch = new System.Diagnostics.Stopwatch();

ISortingAlgorithm[] sortingAlgorithms = { new BubbleSort(), new MergeSort() };

foreach(var sortingAlgorithm in sortingAlgorithms)
{
    watch.Start();
    sortingAlgorithm.Sort(ArrayGenerator.GenerateRandomArray(10000));
    Console.WriteLine($"{sortingAlgorithm.GetType().Name} random: {watch.Elapsed}");

    watch.Restart();
    sortingAlgorithm.Sort(ArrayGenerator.GenerateSortedArray(10000));
    Console.WriteLine($"{sortingAlgorithm.GetType().Name} sorted: {watch.Elapsed}");

    watch.Stop();
    Console.WriteLine();
}