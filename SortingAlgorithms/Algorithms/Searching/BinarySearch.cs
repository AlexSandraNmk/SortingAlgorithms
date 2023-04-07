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
    public sealed class BinarySearch : ISearchingAlgorithm 
    {
        private readonly ISortingAlgorithm _sortingAlgorithm;
        private readonly IArrayValidator _arrayValidator;

        /// <summary>
        /// Initializes a new instance of the BinarySearch class.
        /// </summary>
        /// <param name="sortingAlgorithm">Sorting algorithm that will be used for sorting.</param>
        /// <param name="arrayValidator">Array validator that will validate an array.</param>
        public BinarySearch(ISortingAlgorithm sortingAlgorithm, IArrayValidator arrayValidator)
        {
            _sortingAlgorithm = sortingAlgorithm;
            _arrayValidator = arrayValidator;
        }

        /// <inheritdoc />
        public bool Search<T>(T[] array, T item) where T : IComparable
        {
            if (_arrayValidator.IsSorted(array) is false)
            {
                _sortingAlgorithm.Sort(array);
            }

            int result = SearchInHalf(array, item, 0, array.Length - 1);

            if (result == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// This method searches item in the given half of the array. 
        /// </summary>
        /// <param name="array">The full array in which an item is searched.</param>
        /// <param name="item">An item that is searched in array.</param>
        /// <param name="leftIndex">The first index of the needed half of array.</param>
        /// <param name="rightIndex">The last index of the needed half of array.</param>
        /// <returns>Index of the found item if it is in the array, otherwise returns -1.</returns>
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
