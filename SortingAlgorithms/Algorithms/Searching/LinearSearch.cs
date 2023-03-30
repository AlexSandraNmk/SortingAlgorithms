using SortingAlgorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Algorithms.Searching
{
    public sealed class LinearSearch : ISearchingAlgorithm
    {
        public void Search<T>(T[] array, T item) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].CompareTo(item) == 0)
                {
                    Console.WriteLine($"Item {item} was found at index {i}");
                    return;
                }
            }

            Console.WriteLine($"Item {item} was not found");
        }
    }
}
