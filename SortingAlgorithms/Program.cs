using SortingAlgorithms.Algorithms.Searching;
using SortingAlgorithms.Algorithms.Sorting;
using SortingAlgorithms.Helpers;
using SortingAlgorithms.Interfaces;

ISortingAlgorithm[] sortingAlgorithms = { new BubbleSort(), new MergeSort() };
ISearchingAlgorithm[] searchingAlgorithms = { new LinearSearch(), new BinarySearch() };

int[] randomArray = ArrayGenerator.GenerateRandomArray(10000);
int[] sortedArray = ArrayGenerator.GenerateSortedArray(10000);
var watch = new System.Diagnostics.Stopwatch();

Console.WriteLine("Sortings:");

foreach (var sortingAlgorithm in sortingAlgorithms)
{
    watch.Start();
    sortingAlgorithm.Sort(randomArray);
    Console.WriteLine($"{sortingAlgorithm.GetType().Name} random: {watch.Elapsed}");

    watch.Restart();
    sortingAlgorithm.Sort(sortedArray);
    Console.WriteLine($"{sortingAlgorithm.GetType().Name} sorted: {watch.Elapsed}");

    watch.Stop();
    Console.WriteLine();
}

Console.WriteLine("\nSearchings:");

foreach (var searchingAlgorithm in searchingAlgorithms)
{
    watch.Start();
    searchingAlgorithm.Search(randomArray, 1);
    Console.WriteLine($"{searchingAlgorithm.GetType().Name} random: {watch.Elapsed}");

    watch.Restart();
    searchingAlgorithm.Search(sortedArray, 1);
    Console.WriteLine($"{searchingAlgorithm.GetType().Name} sorted: {watch.Elapsed}");

    watch.Stop();
    Console.WriteLine();
}
