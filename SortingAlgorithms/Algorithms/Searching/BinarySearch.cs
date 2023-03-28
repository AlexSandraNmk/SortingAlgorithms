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
        public void Search(int[] array, int number)
        {
            if (SortedChecker.IsSorted(array) is false)
            {
                ISortingAlgorithm sortingAlgorithm = new MergeSort();
                sortingAlgorithm.Sort(array);
            }

            int result = SearchInHalf(array, number, 0, array.Length - 1);

            if (result == -1)
            {
                Console.WriteLine($"Number {number} was not found");
            }
            else
            {
                Console.WriteLine($"Number {number} was found at index {result}");
            }
        }

        private int SearchInHalf(int[] array, int number, int leftIndex, int rightIndex)
        {
            if (leftIndex <= rightIndex)
            {
                int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

                if (number == array[middleIndex])
                {
                    return middleIndex;
                }

                if (number < array[middleIndex])
                {
                    return SearchInHalf(array, number, leftIndex, middleIndex - 1);
                }
                else
                {
                    return SearchInHalf(array, number, middleIndex + 1, rightIndex);
                }
            }  

            return -1;
        }
    }
}
