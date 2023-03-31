using SortingAlgorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Algorithms.Sorting
{
    public sealed class MergeSort : ISortingAlgorithm
    {
        /// <inheritdoc />
        public void Sort<T>(T[] array) where T : IComparable
        {
            SortArray(array, 0, array.Length - 1);
        }

        private T[] SortArray<T>(T[] array, int leftIndex, int rightIndex) where T : IComparable
        {
            if (leftIndex < rightIndex)
            {
                int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

                SortArray(array, leftIndex, middleIndex);
                SortArray(array, middleIndex + 1, rightIndex);

                MergeArray(array, leftIndex, middleIndex, rightIndex);
            }

            return array;
        }

        private void MergeArray<T>(T[] array, int leftIndex, int middleIndex, int rightIndex) where T : IComparable
        {
            int leftArrayLength = middleIndex - leftIndex + 1;
            int rightArrayLength = rightIndex - middleIndex;
            T[] leftArray = new T[leftArrayLength];
            T[] rightArray = new T[rightArrayLength];

            for (int i = 0; i < leftArrayLength; i++)
            {
                leftArray[i] = array[leftIndex + i];
            }

            for (int i = 0; i < rightArrayLength; i++)
            {
                rightArray[i] = array[middleIndex + 1 + i];
            }

            int j = 0, k = 0, l = leftIndex;

            while (j < leftArrayLength && k < rightArrayLength)
            {
                if (leftArray[j].CompareTo(rightArray[k]) <- 0)
                {
                    array[l++] = leftArray[j++];
                }
                else
                {
                    array[l++] = rightArray[k++];
                }
            }

            while (j < leftArrayLength)
            {
                array[l++] = leftArray[j++];
            }

            while (k < rightArrayLength)
            {
                array[l++] = rightArray[k++];
            }
        }
    }
}
