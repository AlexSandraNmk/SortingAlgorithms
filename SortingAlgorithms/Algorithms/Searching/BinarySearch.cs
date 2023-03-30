using SortingAlgorithms.Algorithms.Sorting;
using SortingAlgorithms.Helpers;
using SortingAlgorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Algorithms.Searching
{
    public class BinarySearch : ISearchingAlgorithm
    {
        public void Search<T>(T[] array, T item) where T : IComparable
        {
            if (SortedChecker.IsSorted(array) is false)
            {
                ISortingAlgorithm sortingAlgorithm = new MergeSort();
                sortingAlgorithm.Sort(array);
            }

            int result = SearchInHalf(array, item, 0, array.Length - 1);

            if (result == -1)
            {
                Console.WriteLine($"Item {item} was not found");
            }
            else
            {
                Console.WriteLine($"Item {item} was found at index {result}");
            }
        }

        private int SearchInHalf<T>(T[] array, T item, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex <= rightIndex)
            {
                int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

                if (item.CompareTo(array[middleIndex]) == 0)
                {
                    return middleIndex;
                }

                if (item.CompareTo(array[middleIndex]) < 0)
                {
                    return SearchInHalf(array, item, leftIndex, middleIndex - 1);
                }
                else
                {
                    return SearchInHalf(array, item, middleIndex + 1, rightIndex);
                }
            }  

            return -1;
        }
    }
}
